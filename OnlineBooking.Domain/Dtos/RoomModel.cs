using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class RoomModel
    {
        public required string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double PricePerDay { get; set; }

        [Required]
        public string PicturePath { get; set; } = "";

        public bool isAvailable { get; set; }

        [Range(0, int.MaxValue)]
        public int maxGuests { get; set; }

        [ForeignKey("RoomType")]
        public long roomTypeId { get; set; }

        [ForeignKey("Hoteli")]
        public long HotelId { get; set; }
    }
}
