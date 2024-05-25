using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class HotelModel
    {
        public required string Name { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Address must be  between  3-30 character")]
        [Required]
        public required string Address { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "City name must be  between  3-30 character")]
        public required string City { get; set; }

        [Required]
        public required string PicturePath { get; set; }

    }
}
