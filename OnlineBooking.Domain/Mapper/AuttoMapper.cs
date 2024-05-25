using AutoMapper;
using Final_Project;
using Final_Project.Models.Hotel;
using OnlineBooking.Domain.Dtos;
using OnlineStore.Core.Entities;

namespace OnlineBooking.Domain.Mapper
{
    public class AuttoMapper:Profile
    {
        public AuttoMapper()
        {
            CreateMap<UserModel, User>().ReverseMap();
              CreateMap<BookingModel,Booking>().ReverseMap();
            CreateMap<HotelModel,Hotel>().ReverseMap();
            CreateMap<Room,RoomModel>().ReverseMap(); 
            CreateMap<RoomType,RoomTypeModel>().ReverseMap();
        }
    }
}
