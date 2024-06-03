using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBooking.Domain.Dtos;

namespace IT_Step_Final.Models
{
    public class RoomViewModel
    { 
        public RoomModel? rooms { get; set; }
        public List<SelectListItem>? HotelList { get; set; }
        public List<SelectListItem>? RoomTypeId { get; set; }
    }
}
