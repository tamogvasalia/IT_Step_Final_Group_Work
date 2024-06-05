using IT_Step_Final;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Core.Entities
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; } = "";//default value
        public string LastName { get; set; } = "";
        public double TotalBudget { get; set; } = 0;
        public virtual IEnumerable<Booking> Books { get; set; }
    }
}
