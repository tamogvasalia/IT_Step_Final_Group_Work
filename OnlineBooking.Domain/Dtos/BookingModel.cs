using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class BookingModel
    {
        public long RoomId { get; set; }

        public required string UserID { get; set; }

        [Required]
        public DateTime checkInTime { get; set; }

        [Required]
        public DateTime checkOutTime { get; set; }

        [Range(0, double.MaxValue)]
        public double totalPrice { get; set; } = 0;

    }
}
