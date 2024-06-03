using IT_Step_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;

namespace IT_Step_Final.Controllers
{
    [Authorize]
    public class RoomRelatedController : Controller
    {
        private readonly IroomRelatedServices roomservices;
        private readonly IbookingRelate bookrelate;
        public RoomRelatedController(IroomRelatedServices roomservices, IbookingRelate bookrelate)
        {
           this.roomservices = roomservices;
            this.bookrelate = bookrelate;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var res = await roomservices.GetAllAsync(new RoomModel());
                return View(res);
            }
            catch (Exception)
            {
                return View(new List<RoomModel>());
            }
        }

        [HttpGet]
        public async Task< ActionResult> Create()//damateba
        {
            RoomViewModel mod = new RoomViewModel();
            var re = await roomservices.GetAllAsync(new RoomTypeModel() { TypeName = "d" });

            mod.RoomTypeId = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var item in re)
            {
                mod.RoomTypeId.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = item.TypeName,
                    Value = item.Id.ToString()
                });
            }

            var Hotels = await bookrelate.GetAllAsync(new HotelModel() { Address = "", City = "", Name = "", PicturePath = "" });

            mod.HotelList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var item in Hotels)
            {
                mod.HotelList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return View(mod);
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoomViewModel model)
        {
            try
            {
                await roomservices.CreateAsync(model.rooms);
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
            var res = await roomservices.GetByIdAsync(id,new RoomModel());
           
            if(res is null)
            {
                return NotFound(id);
            }
            return View(res);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomModel room)
        {
            ArgumentNullException.ThrowIfNull(room, nameof(room));
            try
            {
                await roomservices.UpdateAsync(room);
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
            
            var Room = await roomservices.GetByIdAsync(id, new RoomModel() { Name = "" });
            
            if (Room is not null)
            {
              
                try
                {
                    await roomservices.DeleteAsync(Room);
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
                var res = await roomservices.GetByIdAsync(id, new RoomModel() {  Name = "f"});
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

