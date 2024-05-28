﻿using Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.Repositories
{
    public class RoomTypeRepository : BaseReposiotry, IroomTypeRepository
    {
        private readonly DbSet<RoomType> rooms;
        public RoomTypeRepository(ApplicationDbContext con) : base(con)
        {
            rooms = this._context.Set<RoomType>();
        }

        public async Task AddAsync(RoomType entity)
        {
            try
            {
                if (!rooms.Any(r=> r.TypeName == entity.TypeName))
                {
                    rooms.Add(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            { 
            
                throw new ArgumentException($"Room Type {entity.TypeName} already exists in the database.");
            }
        }
        public async Task DeleteAsync(RoomType entity)
        {
            try
            {
                if(entity != null)
                {
                    rooms.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw new ArgumentException($"Room Type {entity.TypeName} doesn't exist");
            }
        }

        public async Task<IEnumerable<RoomType>> GetAllAsync()
        {
            try
            {
                return await rooms
               .Include(r => r.Rooms)
               .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }          
        }

        public async Task<RoomType> GetByIdAsync(long id)
        {
            return await rooms
                .Include(r => r.Rooms)
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException($"Room Type with {id} id not found");
        }

        public async Task UpdateAsync(RoomType entity)
        {
            try
            {
                var existingType = await GetByIdAsync(entity.Id);
                if(existingType != null)
                {
                    _context.Entry(existingType).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                }
                throw new KeyNotFoundException($"Room Type {entity.Id} not found/doesn't exist");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
