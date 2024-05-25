using OnlineBooking.Domain.Dtos;

namespace OnlineBooking.Domain.Interfaces
{
    public interface IbookingRelate:IcrudService<BookingModel,long>,IcrudService<HotelModel,long>
    {
    }
}
