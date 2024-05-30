using Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.Repositories
{
    public class RoomRepository : BaseReposiotry, IRoomRepository
    {
        private readonly DbSet<Room> rooms;
        public RoomRepository(ApplicationDbContext con) : base(con)
        {
            this.rooms = this._context.Set<Room>();
        }

        public async Task AddAsync(Room entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity,nameof(entity));
                if(await rooms.AnyAsync(io=>io.RoomType == entity.RoomType &&io.maxGuests==entity.maxGuests&&io.isAvailable==entity.isAvailable))
                {
                    await rooms.AddAsync(entity);
                    await _context.SaveChangesAsync();
                }
                throw new ArgumentException("such entity already exist in DB!");
            }
            catch (Exception)
            { 
                throw;
            }
        }

        public async Task DeleteAsync(Room entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity,nameof(entity));

                var re= await rooms.FirstOrDefaultAsync(io=>io.RoomType == entity.RoomType&&io.Name==entity.Name);
                if (re is not null)
                {
                    rooms.Remove(re);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            try
            {
                return await rooms.Include(io=>io.books).ToListAsync(); 

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Room> GetByIdAsync(long id)
        {
            try
            {
                var res =  await rooms.FindAsync(id);

                if(res is not null)
                {
                    return res;
                }
                throw new ArgumentException("No room exist on this ID");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Room entity)
        {
            try
            {
               ArgumentNullException.ThrowIfNull(entity,nameof(entity));
                rooms.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
