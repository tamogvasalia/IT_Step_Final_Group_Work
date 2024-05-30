using IT_Step_Final.Data;
using OnlineBooking.Persistance.Repositories;
using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.UniteOfWorkRelated
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext _context;

        public UniteOfWork(ApplicationDbContext context)
        {
            _context = context;
                
        }

        public IbookingRepository bookReposiotry => new BookRepository(_context);
        public IhotelRepository hotelRepository => new HotelRepository(_context);

        public IRoomRepository roomRepository => new RoomRepository(_context);

        public IroomTypeRepository roomTypeRepository => new RoomTypeRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task saveChanges()
        {
            using (var transact = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transact.CommitAsync();
                }
                catch (Exception)
                {
                    await transact.RollbackAsync();
                }
            }
        }

    }
}
