using IT_Step_Final.Data;

namespace OnlineBooking.Persistance.Repositories
{
    public abstract class BaseReposiotry
    {
        protected readonly ApplicationDbContext _context;

        public BaseReposiotry(ApplicationDbContext context)
        {
                _context= context;
        }

    }
}
