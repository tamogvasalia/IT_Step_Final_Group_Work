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
        protected readonly ApplicationDbContext context;

        public BaseReposiotry(ApplicationDbContext con)
        {
                this.context = con;
        }

    }
}
