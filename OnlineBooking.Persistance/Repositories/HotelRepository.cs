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
            hotelSet = this._context.Set<Hotel>();
        }

        public async Task AddAsync(Hotel entity)
        {
            await hotelSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var hotel = await GetByIdAsync(id);
            if (hotel != null)
            {
                hotelSet.Remove(hotel);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Hotel with {id} not found");
            }
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await hotelSet
                .Include(r => r.Rooms)
                .ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(long id)
        {
            return await hotelSet
                 .Include(r => r.Rooms)
                 .FirstOrDefaultAsync(h => h.Id == id) ?? throw new KeyNotFoundException($"Hotel with {id} id not found");
        }

        public async Task UpdateAsync(Hotel entity)
        {
            var oldHotel = await GetByIdAsync(entity.Id);
            if (oldHotel == null)
            {
                throw new KeyNotFoundException($"Hotel with id {entity.Id} not found");             
            }

            _context.Entry(oldHotel).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
