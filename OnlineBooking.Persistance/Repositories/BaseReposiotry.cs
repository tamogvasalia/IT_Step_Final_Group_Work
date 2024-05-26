using Final_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
