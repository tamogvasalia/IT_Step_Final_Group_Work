using AutoMapper;
using OnlineBooking.Persistance.UniteOfWorkRelated;

namespace OnlineBooking.Domain.Services
{
    public abstract class BaseService
    {

        protected readonly IMapper map;
        public readonly IUniteOfWork work;

        #region Constructors
        public BaseService(IMapper map,IUniteOfWork wor)
        {
            this.map= map;
            this.work= wor;
        }

        public BaseService(IMapper map)
        {
                this.map= map;
        }
        #endregion
    }
}
