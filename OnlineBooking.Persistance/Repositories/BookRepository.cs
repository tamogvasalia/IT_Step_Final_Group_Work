using Final_Project;
using Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.Repositories
{
    public class BookRepository : BaseReposiotry, IbookingRepository
    {

        private DbSet<Room> rooms { get; set; }
        public BookRepository(ApplicationDbContext con) : base(con)
        {
            rooms = this.context.Set<Room>();
        }

        public Task AddAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Booking entity)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
