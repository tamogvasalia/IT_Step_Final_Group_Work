using Microsoft.EntityFrameworkCore;
using IT_Step_Final.Models.Hotel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineStore.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace IT_Step_Final.Data
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

