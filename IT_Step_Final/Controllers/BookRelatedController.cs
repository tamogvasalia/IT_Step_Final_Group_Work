using IT_Step_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;
using OnlineStore.Core.Entities;

namespace IT_Step_Final.Controllers
{

    [Authorize]
    public class BookRelatedController : Controller
    {
        private readonly IbookingRelate bookrelate;
        private readonly IroomRelatedServices roomRelatedServices;
        private readonly UserManager<User> _userManager;
        public BookRelatedController(IroomRelatedServices ser,IbookingRelate bookrelate, UserManager<User> userManager)
        {
            this.bookrelate = bookrelate;
            _userManager = userManager;
            roomRelatedServices = ser;
        }

        public async Task<IActionResult> Index()//mtavari gverdi
        {
            try
            {
                var identity = new BookingModel { UserID = "ddfdf" };
                var bookings = await bookrelate.GetAllAsync(identity);
                return View(bookings);

            }
            catch (Exception)
            {
                return View(new List<BookingModel>());
            }
        }

        [HttpGet]
        public async Task<ActionResult> Create()//damateba
        {
            var bookingunite = new BookingUniteModel();
            var rooms = await roomRelatedServices.GetAllAsync(new RoomModel());
            bookingunite.HotelList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var item in rooms)//chavwert bazashi arsebul sastumrooebs
            {
                bookingunite.HotelList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                });
            }
            
            return View(bookingunite);
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookingUniteModel model)
        {
            var room = await roomRelatedServices.GetByIdAsync(model.bookingModel.RoomId,new RoomModel());
            var pricePerDay = room.PricePerDay;
            var days = (model.bookingModel.checkOutTime - model.bookingModel.checkInTime).TotalDays;
            await Console.Out.WriteLineAsync( model.bookingModel.totalPrice.ToString());
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    // login pageze ushvebs
                    return RedirectToAction("Login", "Account");
                }
                await Console.Out.WriteLineAsync(  model.bookingModel.RoomId.ToString());
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null)
                {
                    ModelState.AddModelError("", "User not found.");
                    return View(model);
                }
                model.bookingModel.UserID = user.Id;
                model.bookingModel.totalPrice = days * pricePerDay;
                await bookrelate.CreateAsync(model.bookingModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)//redaqtireba
        {

            var res=await bookrelate.GetByIdAsync(id,new BookingModel(){UserID="456f"});

            if (res == null)
            {
                return NotFound();
            }
            var bookingunite = new BookingUniteModel();
            var rooms = await roomRelatedServices.GetAllAsync(new RoomModel());
            bookingunite.HotelList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var item in rooms)//chavwert bazashi arsebul sastumrooebs
            {
                bookingunite.HotelList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                });
            }
            bookingunite.bookingModel = res;
            return View(bookingunite);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookingUniteModel booking)
        {
            ArgumentNullException.ThrowIfNull(booking, nameof(booking));
            try
            {
                await bookrelate.UpdateAsync(booking.bookingModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exp)
            {
                return Content(exp.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(long id)// washlis funqcia
        {
            var bookmodel = await  bookrelate.GetByIdAsync(id,new BookingModel() { UserID="df3"});
            if(bookmodel is not null)
            {
                try
                {
                    await bookrelate.DeleteAsync(bookmodel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exp)
                { 
                    return BadRequest(exp.Message);
                }

            }
            return BadRequest(" No such entity found");
        }

        [HttpGet]
        public async Task<ActionResult> Details(long id)// detaail action 
        {
            try
            {
                var res = await bookrelate.GetByIdAsync(id, new BookingModel() { UserID = "dddf" });
                if (res is null) return NotFound("no entity found");
                return View(res);
            }
            catch (Exception)
            {
                return BadRequest($"Could not find {id}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            var hotels = await bookrelate.GetAllAsync(new BookingModel());
            if (!string.IsNullOrEmpty(query))
            {
                hotels = hotels.Where(h => h.checkInTime.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) ||
                              h.RoomId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View("Index", hotels);
        }

    }
}
