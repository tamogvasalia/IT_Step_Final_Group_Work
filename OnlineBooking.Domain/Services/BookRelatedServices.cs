using AutoMapper;
using IT_Step_Final;
using IT_Step_Final.Models.Hotel;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Exceptions;
using OnlineBooking.Domain.Interfaces;
using OnlineBooking.Persistance.UniteOfWorkRelated;
using System.Diagnostics;

namespace OnlineBooking.Domain.Services
{
    [DebuggerDisplay("BookingRelateServices")]
    public class BookRelatedServices : BaseService, IbookingRelate
    {
        public BookRelatedServices(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        #region Create
        public async Task CreateAsync(BookingModel entity)
        {

            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            var mapped = map.Map<Booking>(entity);

            if (mapped is not null)
            {
                await work.bookReposiotry.AddAsync(mapped);
            }
            else
            {
                throw new BookRelatedException("Mapped  not was succesfully");
            }
        }

        public async Task CreateAsync(HotelModel entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));
                if (entity.Address is null)
                {
                    throw new BookRelatedException("Address is null there");
                }
                if(entity.City is null)
                {
                    throw new BookRelatedException("City is null there");
                }
                var mapped = map.Map<Hotel>(entity);
                if (mapped is not null)
                {
                    await work.hotelRepository.AddAsync(mapped);
                }
                else
                {
                    throw new BookRelatedException("Mapped  not was succesfully");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Delete
        public async Task DeleteAsync(BookingModel entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));
                var mapped = map.Map<Booking>(entity);
                if (mapped is null)
                {
                    throw new BookRelatedException("mapped  not was successfully");
                }
                await work.bookReposiotry.DeleteAsync(mapped);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(HotelModel entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));
                var mapped = map.Map<Hotel>(entity);
                if (mapped is null)
                {
                    throw new BookRelatedException("mapped  not was successfully , while mapping hotel model");
                }
                await work.hotelRepository.DeleteAsync(mapped);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<BookingModel>> GetAllAsync(BookingModel identity)
        {
            try
            {
                var res = await work.bookReposiotry.GetAllAsync();
                if(res.Any())
                {
                    var mappedObjects=map.Map<IEnumerable<BookingModel>>(res);
                    return mappedObjects;
                }
                else
                {
                    throw new BookRelatedException("No Booking Exist");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<HotelModel>> GetAllAsync(HotelModel identity)
        {
            try
            {
                var res = await work.hotelRepository.GetAllAsync();
                if (res.Any())
                {
                    var mappedObjects = map.Map<IEnumerable<HotelModel>>(res);
                    return mappedObjects;
                }
                else
                {
                    throw new BookRelatedException("No Booking Exist");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetByIdAsync
        public async Task<BookingModel> GetByIdAsync(long id, BookingModel identity)
        {
            try
            {
                var res = await work.bookReposiotry.GetByIdAsync(id);
                if(res is not null)
                {
                    var mapped= map.Map<BookingModel>(res);
                    return mapped;
                }
                throw new BookRelatedException("No entity found while searching for record");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HotelModel> GetByIdAsync(long id, HotelModel identity)
        {
            try
            {
                var res = await work.hotelRepository.GetByIdAsync(id);
                if (res is not null)
                {
                    var mapped = map.Map<HotelModel>(res);
                    return mapped;
                }
                throw new BookRelatedException("No entity found while searching for record");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update
        public async Task UpdateAsync(BookingModel entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));
                var mapped = map.Map<Booking>(entity);
                if(mapped is  null)
                {
                    throw new BookRelatedException("Mapped was Unsuccesfull");
                }
                await work.bookReposiotry.UpdateAsync(mapped);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(HotelModel entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));
                var mapped = map.Map<Hotel>(entity);
                if (mapped is null)
                {
                    throw new BookRelatedException("Mapped was Unsuccesfull");
                }
                await work.hotelRepository.UpdateAsync(mapped);
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetByUserId
        public async Task<IEnumerable<BookingModel>> GetUserByIdAsync(string id,BookingModel model)
        {
            var allBookings = await work.bookReposiotry.GetAllAsync();
            var userBookings = allBookings.Where(b => b.UserID == id).ToList();
            return map.Map<IEnumerable<BookingModel>>(userBookings);
        }

        public Task<IEnumerable<BookingModel>> GetUserByIdAsync(string id, HotelModel identity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
