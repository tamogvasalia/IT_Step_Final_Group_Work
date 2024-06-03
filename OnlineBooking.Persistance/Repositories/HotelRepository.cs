using IT_Step_Final.Data;
using IT_Step_Final.Models.Hotel;
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
            try
            {
                await hotelSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ArgumentException($"Hotel {entity.Name} already exists in the database");
            }
        }

        public async Task DeleteAsync(Hotel entity)
        {
            try
            {
                if (entity != null)
                {
                    var ent = hotelSet.FirstOrDefault(ent => ent.Name == entity.Name
                        );
                    if (ent != null)
                    {
                        hotelSet.Remove(ent);
                        await _context.SaveChangesAsync();
                    }
                } 
            }
            catch (Exception)
            {

                throw new ArgumentException($"{entity.Name} doesn't exist. nothing to delete");
            }
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            try
            {
                return await hotelSet
                .Include(r => r.Rooms)
                .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
                
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

            oldHotel.PicturePath = entity.PicturePath;
            oldHotel.Address= entity.Address;
            oldHotel.Name = entity.Name;
            oldHotel.City = entity.City;
            await _context.SaveChangesAsync();
        }
    }
}
