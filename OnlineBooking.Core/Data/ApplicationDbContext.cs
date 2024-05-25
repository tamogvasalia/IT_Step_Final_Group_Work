using Microsoft.EntityFrameworkCore;
using Final_Project.Models.Hotel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineStore.Core.Entities;

namespace Final_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}