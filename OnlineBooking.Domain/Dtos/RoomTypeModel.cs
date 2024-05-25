using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class RoomTypeModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "room type must be between 3 to 50 character")]
        public required string TypeName { get; set; }

    }
}
