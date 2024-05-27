using AutoMapper;
using Final_Project;
using Final_Project.Models.Hotel;
using Microsoft.Extensions.Logging;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;
using OnlineBooking.Persistance.Repositories;
using OnlineBooking.Persistance.UniteOfWorkRelated;

namespace OnlineBooking.Domain.Services
{
    public class BookRelatedServices : BaseService, IbookingRelate
    {
        private readonly ILogger<BookRepository> _logger;

        public BookRelatedServices(IMapper map, IUniteOfWork wor,ILogger<BookRepository> logger) : base(map, wor)
        {
            _logger = logger;
        }

        public async Task CreateAsync(BookingModel entity)
        {
            try
            {
                var bookingEntity = map.Map<Booking>(entity);
                await work.bookReposiotry.AddAsync(bookingEntity);
                await work.saveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"there is an error adding your booking");
                throw new ArgumentException("Error adding booking");
            }
        }

        public async Task CreateAsync(HotelModel entity)
        {
            try
            {
                var hotelEntity = map.Map<Hotel>(entity);
                await work.hotelRepository.AddAsync(hotelEntity);
                await work.saveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "there is an error creating hotel");
                throw new ArgumentException("Error! cant create hotel");
            }
        }

        public async Task DeleteAsync(BookingModel entity)
        {
            try
            {
                var bookingEntity = map.Map<Booking>(entity);
                await work.bookReposiotry.DeleteAsync(bookingEntity);
                await work.saveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting booking");
                throw new ArgumentException("Error occured while trying to delete booking");
            }
        }

        public async Task DeleteAsync(HotelModel entity)
        {
            try
            {
                var hotelEntity = map.Map<Hotel>(entity);
                await work.hotelRepository.DeleteAsync(hotelEntity);
                await work.saveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting hotel!");
                throw new ArgumentException("Error occured while trying to delete hotel");
            }
        }

        public async Task<IEnumerable<BookingModel>> GetAllAsync(BookingModel identity)
        {
            try
            {
                var bookings = await work.bookReposiotry.GetAllAsync();
                return map.Map<IEnumerable<BookingModel>>(bookings);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving bookings");
                throw new ArgumentException("error occured while trying to retreive the bookings");
            }
        }

        public async Task<IEnumerable<HotelModel>> GetAllAsync(HotelModel identity)
        {
            try
            {
                var hotels = await work.hotelRepository.GetAllAsync();
                return map.Map<IEnumerable<HotelModel>>(hotels);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotels");
                throw new ArgumentException("error occured while trying to retreive the hotels");
            }
        }

        public async Task<BookingModel> GetByIdAsync(long id, BookingModel identity)
        {
            try
            { 
                var booking = await work.bookReposiotry.GetByIdAsync(id);
                return map.Map<BookingModel>(booking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving booking");
                throw new ArgumentException("Error occured while trying to retreive booking");
            }
        }

        public async Task<HotelModel> GetByIdAsync(long id, HotelModel identity)
        {
            try
            {
                var hotel = await work.hotelRepository.GetByIdAsync(id);
                return map.Map<HotelModel>(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving booking");
                throw new ArgumentException("Error occured while trying to retreive booking");
            }
        }

        public async Task UpdateAsync(BookingModel entity)
        {
            try
            {
                var bookEntity = map.Map<Booking>(entity);
                await work.bookReposiotry.UpdateAsync(bookEntity);
                await work.saveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating the booking");
                throw new ArgumentException("Error occured while updating booking");
            }
        }

        public async Task UpdateAsync(HotelModel entity)
        {
            try
            {
                var hotelEntity = map.Map<Hotel>(entity);
                await work.hotelRepository.UpdateAsync(hotelEntity);
                await work.saveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to update hotel");
                throw new ArgumentException("Couldn't update the hotel");
            }
        }
    }
}
