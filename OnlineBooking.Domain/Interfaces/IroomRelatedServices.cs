using OnlineBooking.Domain.Dtos;

namespace OnlineBooking.Domain.Interfaces
{
    public interface IroomRelatedServices:IcrudService<RoomModel,long>,IcrudService<RoomTypeModel,long>
    {
    }
}
