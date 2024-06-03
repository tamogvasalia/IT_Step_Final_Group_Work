
using IT_Step_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;

namespace IT_Step_Final.Controllers
{
    [Authorize]
    public class HotelController(IbookingRelate booking) : Controller
    {
        private readonly IbookingRelate _bookingRelate= booking;
        public async Task<ActionResult> Index()
        {
            try
            {

                var res = await _bookingRelate.GetAllAsync(new HotelModel() { Address = "", City = "", Name = "", PicturePath = "" });
                return View(res);
            }
            catch
            {
                return View(new List<HotelModel>());
            }
        }

        public ActionResult Create()//damateba
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(HotelModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookingRelate.CreateAsync(model);
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

            var res = await _bookingRelate.GetByIdAsync(id, new HotelModel() {Address="",City="",Name="",PicturePath="" });
            if (res == null)
            {
                return NotFound();
            }
            return View(res);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HotelModel booking)
        {
            try
            {
                await _bookingRelate.UpdateAsync(booking);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(long id)// washlis funqcia
        {
            var bookmodel = await _bookingRelate.GetByIdAsync(id, new HotelModel() {Address="",City="",Name="",PicturePath=""});
            if (bookmodel is not null)
            {
                try
                {
                    await _bookingRelate.DeleteAsync(bookmodel);
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
                var res = await _bookingRelate.GetByIdAsync(id, new HotelModel() { Address="d",City="f",Name="f",PicturePath=""});
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
