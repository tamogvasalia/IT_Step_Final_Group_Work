using AutoMapper;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;
using OnlineBooking.Persistance.UniteOfWorkRelated;

namespace OnlineBooking.Domain.Services
{
    public class BookRelatedServices : BaseService, IbookingRelate
    {
        public BookRelatedServices(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public Task CreateAsync(BookingModel entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(HotelModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(BookingModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(HotelModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookingModel> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BookingModel entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(HotelModel entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<HotelModel>> IcrudService<HotelModel, long>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<HotelModel> IcrudService<HotelModel, long>.GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
