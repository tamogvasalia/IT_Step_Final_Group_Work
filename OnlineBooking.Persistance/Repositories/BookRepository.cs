using Final_Project;
using Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.Repositories
{
    public class BookRepository : BaseReposiotry, IbookingRepository
    {

        private DbSet<Booking> booking { get; set; }
        public BookRepository(ApplicationDbContext con) : base(con)
        {
            this.booking = this.context.Set<Booking>();
        }

        public async Task AddAsync(Booking entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));

                await booking.AddAsync(entity);

                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteAsync(Booking entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity,nameof(entity));
                booking.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            { 
                throw;
            }
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
