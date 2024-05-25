using Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooking.Persistance.Repositories
{
    public class RoomRepository : BaseReposiotry, IRoomRepository
    {
        private readonly DbSet<Room> rooms;
        public RoomRepository(ApplicationDbContext con) : base(con)
        {
            this.rooms = this.context.Set<Room>();
        }

        public Task AddAsync(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
