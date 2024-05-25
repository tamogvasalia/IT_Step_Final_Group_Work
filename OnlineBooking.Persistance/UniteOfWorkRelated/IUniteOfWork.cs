using OnlineStore.Core.Interfaces;

namespace OnlineBooking.Persistance.UniteOfWorkRelated
{
    public interface IUniteOfWork : IDisposable
    { 
        public IbookingRepository bookReposiotry { get;}

        public IhotelRepository hotelRepository { get;}

        public IRoomRepository roomRepository { get; }

        public IroomTypeRepository roomTypeRepository { get;}

        Task saveChanges();
    }
}
