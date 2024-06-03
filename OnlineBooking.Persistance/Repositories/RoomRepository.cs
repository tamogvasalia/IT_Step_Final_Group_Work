using IT_Step_Final.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Interfaces;
using System.Threading.Channels;

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
                if (!await rooms.AnyAsync(i => i.Name == entity.Name))
                {
                    await rooms.AddAsync(entity);
                    await _context.SaveChangesAsync();
                }
                //throw new ArgumentException("such entity already exist in DB!");
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

                var res=await rooms.FindAsync(entity.Id);
                if (res is not null)
                {
                    rooms.Remove(res);
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
                var res= await rooms.FindAsync(entity.Id);
                if (res is not null)
                {
                    res.PicturePath= entity.PicturePath;
                    res.PricePerDay = entity.PricePerDay;
                    res.isAvailable = entity.isAvailable;       
                    res.maxGuests = entity.maxGuests;
                    res.Name = entity.Name;
                    rooms.Update(res);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
