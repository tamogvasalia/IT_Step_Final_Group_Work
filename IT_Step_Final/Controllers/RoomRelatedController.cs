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

        public RoomRelatedController(IroomRelatedServices roomservices)
        {
                this.roomservices = roomservices;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();//method for  preview list of avalible  rooms
        }

        public ActionResult CreateRoomAsync()//for view// add new room view
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(CreateRoomAsync))]
        public Task CreateRoomAsync([FromBody] RoomModel entity)//add  room request
        {
            throw new NotImplementedException();
        }

        public ActionResult CreateroomTypeAsyncRoom()//for view
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public Task CreateroomTypeAsyncRoom([FromBody]RoomTypeModel entity)
        {
            throw new NotImplementedException();
        }


        [HttpDelete]
        [Route("{id:long}")]
        public Task DeleteAsync([FromRoute]long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("[action]/{id:long}")]
        public Task DeleteroomAsync([FromRoute]long id)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("[action]")]
        public Task<IEnumerable<RoomModel>> GetAllRoomAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetAllRoomTypeAsync))]
        public Task<IEnumerable<RoomTypeModel>> GetAllRoomTypeAsync(RoomTypeModel identity)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetRoomByIdAsync))]
        public Task<RoomModel> GetRoomByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(nameof(GetRoomTypeByIdAsync))]
        public Task<RoomTypeModel> GetRoomTypeByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ActionResult UpdateRoomAsync()//add view for page
        {
            return View();
        }

        [HttpPost]
        [Route("room/{id:long}")]
        public Task UpdateRoomAsync([FromRoute]long id,[FromBody]RoomModel entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult UpdateRoomTypeAsync()//add view for page
        {
            return View();
        }

        [HttpPost]
        [Route("roomType/{id:long}")]
        public Task UpdateAsync([FromRoute] long id,[FromBody]RoomTypeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
