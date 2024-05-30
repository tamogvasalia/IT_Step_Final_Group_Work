using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBooking.Domain.Dtos;

namespace IT_Step_Final.Models
{
    public class BookingUniteModel
    {
        public BookingModel bookingModel { get; set; }
        public List<SelectListItem> HotelList { get; set; }
    }
}   
