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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed users
            modelBuilder.Entity<User>().HasData(
                new User { Id = "user1", UserName = "user1@example.com", Email = "user1@example.com", FirstName = "John", LastName = "Doe" },
                new User { Id = "user2", UserName = "user2@example.com", Email = "user2@example.com", FirstName = "Jane", LastName = "Doe" }
            );

            // seed hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel California", Address = "42 Sunset Boulevard", City = "Los Angeles", PicturePath = "hotelcalifornia.jpg" },
                new Hotel { Id = 2, Name = "The Grand Budapest Hotel", Address = "1 Republic Avenue", City = "Zubrowka", PicturePath = "grandbudapest.jpg" }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, RoomId = 1, UserID = "user1", checkInTime = DateTime.Now.AddDays(-10), checkOutTime = DateTime.Now.AddDays(-5), totalPrice = 500 },
                new Booking { Id = 2, RoomId = 2, UserID = "user2", checkInTime = DateTime.Now.AddDays(-3), checkOutTime = DateTime.Now.AddDays(-1), totalPrice = 300 });
            // seed rooms
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Room 101", PricePerDay = 100, PicturePath = "room101.jpg", isAvailable = true, maxGuests = 2, roomTypeId = 1, HotelId = 1 },
                new Room { Id = 2, Name = "Room 102", PricePerDay = 150, PicturePath = "room102.jpg", isAvailable = true, maxGuests = 3, roomTypeId = 2, HotelId = 1 }
            );
            // seed room types
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { Id = 1, TypeName = "Single" },
                new RoomType { Id = 2, TypeName = "Double" }
            );
        }
    }
}
