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

        public Task<IEnumerable<BookingModel>> GetAllAsync(BookingModel identity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HotelModel>> GetAllAsync(HotelModel identity)
        {
            throw new NotImplementedException();
        }

        public Task<BookingModel> GetByIdAsync(long id, BookingModel identity)
        {
            throw new NotImplementedException();
        }

        public Task<HotelModel> GetByIdAsync(long id, HotelModel identity)
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
    }
}
