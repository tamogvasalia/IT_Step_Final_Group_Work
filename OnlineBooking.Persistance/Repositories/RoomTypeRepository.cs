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
    public class RoomTypeRepository : BaseReposiotry, IroomTypeRepository
    {
        private readonly DbSet<RoomType> rooms;
        public RoomTypeRepository(ApplicationDbContext con) : base(con)
        {
            rooms = this._context.Set<RoomType>();
        }

        public Task AddAsync(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomType> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
