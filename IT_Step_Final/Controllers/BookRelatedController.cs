using IT_Step_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;
using OnlineStore.Core.Entities;

namespace IT_Step_Final.Controllers
{

    //[Authorize]
    public class BookRelatedController : Controller
    {
        private readonly IbookingRelate bookrelate;
        private readonly UserManager<User> _userManager;
        public BookRelatedController(IbookingRelate bookrelate, UserManager<User> userManager)
        {
            this.bookrelate = bookrelate;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()//mtavari gverdi
        {
            //if (User.Identity is null)
            //{
            //    return Unauthorized("first you must authorize");
            //}
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //if (user == null)
            //{
            //    return Unauthorized();
            //}
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

        public async Task<ActionResult> Create()//damateba
        {
            var bookingunite = new BookingUniteModel();
            var hotels=await bookrelate.GetAllAsync(new HotelModel { Address="undefined",City="undefined",Name="undefined",PicturePath="undefined" });
            bookingunite.HotelList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var item in hotels)//chavwert bazashi arsebul sastumrooebs
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
        public async Task<ActionResult> Create(BookingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    model.UserID = user.Id;
                   await  bookrelate.CreateAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Create));
                }
            }
            else
            {
                return BadRequest("Model state is not valid");
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
            var hotels = await bookrelate.GetAllAsync(new HotelModel { Address = "undefined", City = "undefined", Name = "undefined", PicturePath = "undefined" });
            bookingunite.HotelList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var item in hotels)//chavwert bazashi arsebul sastumrooebs
            {
                bookingunite.HotelList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                });
            }
            bookingunite.bookingModel = res;
            return View(res);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookingModel booking)
        {
             ArgumentNullException.ThrowIfNull(booking, nameof(booking));
            if (ModelState.IsValid)
            {
                try
                {
                    await bookrelate.UpdateAsync(booking);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return View(booking);
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
    }
}
