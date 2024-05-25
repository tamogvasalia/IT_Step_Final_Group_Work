using Final_Project.Data;
using Final_Project.Models.Hotel;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.Repositories
{
    public class HotelRepository : BaseReposiotry, IhotelRepository
    {
        private readonly DbSet<Hotel> hotelSet;
        public HotelRepository(ApplicationDbContext con) : base(con)
        {
            hotelSet= this.context.Set<Hotel>();
        }

        public Task AddAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hotel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}
