using Final_Project.Data;
using OnlineBooking.Persistance.Repositories;
using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.UniteOfWorkRelated
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext context;

        public UniteOfWork(ApplicationDbContext con)
        {
            this.context = con;
                
        }

        public IbookingRepository bookReposiotry => new BookRepository(context);
        public IhotelRepository hotelRepository => new HotelRepository(context);

        public IRoomRepository roomRepository => new RoomRepository(context);

        public IroomTypeRepository roomTypeRepository => new RoomTypeRepository(context);

        public void Dispose()
        {
           context.Dispose();
        }

        public async Task saveChanges()
        {
            using (var transact = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    await context.SaveChangesAsync();
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
