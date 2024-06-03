using IT_Step_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;

namespace IT_Step_Final.Controllers
{
    [Authorize]
    public class RoomTypeController : Controller
    {
        private readonly IroomRelatedServices ser;

        public RoomTypeController(IroomRelatedServices ser)
        {
          this.ser = ser;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var res = await ser.GetAllAsync(new RoomTypeModel() { TypeName = "" });
                if(res is null) return NotFound();

                return View(res);
            }
            catch (Exception exp)
            {
                return View(new List<RoomTypeModel>());
            }
        }

        [HttpGet]
        public ActionResult Create()//damateba
        {
            return View(); ;
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoomTypeModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ser.CreateAsync(model);
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
            try
            {
                var res = await ser.GetByIdAsync(id, new RoomTypeModel() { TypeName = "" });
                if (res is null) return NotFound();
                return View(res);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomTypeModel room)
        {
            ArgumentNullException.ThrowIfNull(room, nameof(room));
            if (ModelState.IsValid)
            {
                try
                {
                    await ser.UpdateAsync(room);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return View(room);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(long id)// washlis funqcia
        {
            var Room = await ser.GetByIdAsync(id, new RoomTypeModel() { TypeName=""});
            if (Room is not null)
            {
                try
                {
                    await ser.DeleteAsync(Room);
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
                var res = await ser.GetByIdAsync(id, new RoomTypeModel() { TypeName="d" });
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
