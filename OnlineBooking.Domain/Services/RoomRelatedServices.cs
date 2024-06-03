using AutoMapper;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Exceptions;
using OnlineBooking.Domain.Interfaces;
using OnlineBooking.Persistance.UniteOfWorkRelated;
using System.Diagnostics;

namespace OnlineBooking.Domain.Services
{

    [DebuggerDisplay(value: "RoomRelatedServices")]
    public class RoomRelatedServices : BaseService, IroomRelatedServices
    {
        public RoomRelatedServices(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        #region Create
        public async Task CreateAsync(RoomModel entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(entity.Name) && !string.IsNullOrEmpty(entity.PicturePath))
                {
                    var mapped = map.Map<Room>(entity);
                    if (mapped is not null)
                    {
                        await work.roomRepository.AddAsync(mapped);
                    }
                    else
                    {
                        throw new RoomServiceRelateException("Mapped was not succesfully");
                    }
                }
                else
                {
                    throw new RoomServiceRelateException(nameof(entity));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateAsync(RoomTypeModel entity)
        {

            try
            {
                if (!string.IsNullOrEmpty(entity.TypeName))
                {
                    var mapped = map.Map<RoomType>(entity);
                    if ((mapped is not null))
                    {
                        await work.roomTypeRepository.AddAsync(mapped);
                    }
                    else
                    {
                        throw new RoomServiceRelateException("Mapped was not succesfully");
                    }
                }
                else
                {
                    throw new RoomServiceRelateException(nameof(entity));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region DeleteAsync
        public async Task DeleteAsync(RoomModel entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));
                var mapped = map.Map<Room>(entity);
                if (mapped is not null)
                {
                    await work.roomRepository.DeleteAsync(mapped);
                }
                else
                {
                    throw new RoomServiceRelateException("Mapped was not succesfully");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(RoomTypeModel entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));
                var mapped = map.Map<RoomType>(entity);
                if (mapped is not null)
                {
                    await work.roomTypeRepository.DeleteAsync(mapped);
                }
                else
                {
                    throw new RoomServiceRelateException("Mapped was not succesfully");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<RoomModel>> GetAllAsync(RoomModel identity)
        {
            try
            {
                var res = await work.roomRepository.GetAllAsync();
                if(res.Any())
                {
                    var mappedObjects = map.Map<IEnumerable<RoomModel>>(res);
                    return mappedObjects;
                }
                throw new RoomServiceRelateException(" No rooms Exist");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RoomTypeModel>> GetAllAsync(RoomTypeModel identity)
        {
            try
            {
                var res = await work.roomTypeRepository.GetAllAsync();
                if (res.Any())
                {
                    var mappedObjects = map.Map<IEnumerable<RoomTypeModel>>(res);
                    return mappedObjects;
                }
                throw new RoomServiceRelateException(" No roomsTypes Exist");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetByIdAsync
        public async Task<RoomModel> GetByIdAsync(long id, RoomModel identity)
        {
            try
            {
                var res = await work.roomRepository.GetByIdAsync(id);
                if (res is not null)
                {
                    var mappedObjects = map.Map<RoomModel>(res);
                    return mappedObjects;
                }
                throw new RoomServiceRelateException(" No room Exist");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomTypeModel> GetByIdAsync(long id, RoomTypeModel identity)
        {
            try
            {
                var res = await work.roomTypeRepository.GetByIdAsync(id);
                if (res is not null)
                {
                    var mappedObjects = map.Map<RoomTypeModel>(res);
                    return mappedObjects;
                }
                throw new RoomServiceRelateException(" No roomType Exist");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<BookingModel>> GetUserByIdAsync(string id, RoomModel identity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingModel>> GetUserByIdAsync(string id, RoomTypeModel identity)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Update
        public async Task UpdateAsync(RoomModel entity)
        {
            try
            {
             ArgumentNullException.ThrowIfNull(entity,nameof(entity));
                var mapped= map.Map<Room>(entity);
                if(mapped is null)
                {
                    throw new RoomServiceRelateException("Mapped  not was successfully :(");
                }
                await work.roomRepository.UpdateAsync(mapped);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(RoomTypeModel entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));
                var mapped = map.Map<RoomType>(entity);
                if (mapped is null)
                {
                    throw new RoomServiceRelateException("Mapped  not was successfully :(");
                }
              
                await work.roomTypeRepository.UpdateAsync(mapped);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
