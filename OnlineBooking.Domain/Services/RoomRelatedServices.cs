using AutoMapper;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;
using OnlineBooking.Persistance.UniteOfWorkRelated;

namespace OnlineBooking.Domain.Services
{
    public class RoomRelatedServices : BaseService, IroomRelatedServices
    {
        public RoomRelatedServices(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public Task CreateAsync(RoomModel entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(RoomTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RoomModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RoomTypeModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomModel> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RoomModel entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RoomTypeModel entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<RoomTypeModel>> IcrudService<RoomTypeModel, long>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<RoomTypeModel> IcrudService<RoomTypeModel, long>.GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
