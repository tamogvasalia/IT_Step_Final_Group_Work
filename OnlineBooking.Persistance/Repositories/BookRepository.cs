﻿using IT_Step_Final;
using IT_Step_Final.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.Repositories
{
    public class BookRepository : BaseReposiotry, IbookingRepository
    {

        private DbSet<Booking> booking { get; set; }
        public BookRepository(ApplicationDbContext con) : base(con)
        {
            this.booking = this._context.Set<Booking>();
        }

        public async Task AddAsync(Booking entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity, nameof(entity));

                await booking.AddAsync(entity);

                await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
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
                throw new ArgumentNullException("No entity FOund on this ID");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await booking.Include(io => io.user).Include(io => io.Room).ToListAsync();
        }
    }
}
