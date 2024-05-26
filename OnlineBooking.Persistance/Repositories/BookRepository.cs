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

        public async Task DeleteAsync(Booking entity)
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

        public async Task UpdateAsync(Booking entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity,nameof (entity));
                booking.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Booking> GetByIdAsync(long id)
        {
            try
            {
                var res = await booking.FindAsync(id);    
                if(res is not null)
                {
                    return res;
                }
              throw new ArgumentException("No Entity found on this id");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            try
            {
                return await booking.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
