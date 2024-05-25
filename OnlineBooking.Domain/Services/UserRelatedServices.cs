using AutoMapper;
using OnlineBooking.Domain.Dtos;
using OnlineBooking.Domain.Interfaces;
using OnlineBooking.Persistance.UniteOfWorkRelated;

namespace OnlineBooking.Domain.Services
{
    public class UserRelatedServices : BaseService, IUserRelated
    {
        public UserRelatedServices(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public Task CreateAsync(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
