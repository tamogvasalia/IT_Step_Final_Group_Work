using AutoMapper;
using IT_Step_Final;
using IT_Step_Final.Models.Hotel;
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
