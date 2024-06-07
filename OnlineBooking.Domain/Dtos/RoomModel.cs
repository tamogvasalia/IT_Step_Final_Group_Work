using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class RoomModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage ="Name is required :(")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name format Is not valid")]
        public string? Name { get; set; }

        [Range(0, double.MaxValue)]
        public double PricePerDay { get; set; }

        [Required]
        public string PicturePath { get; set; } = "";

        [Required]
        public bool isAvailable { get; set; }

        [Range(0, int.MaxValue)]
        public int maxGuests { get; set; }

        [ForeignKey("RoomType")]
        public long roomTypeId { get; set; }

        [ForeignKey("Hoteli")]
        public long HotelId { get; set; }

        public virtual RoomTypeModel RoomType { get; set; }
    }
}
