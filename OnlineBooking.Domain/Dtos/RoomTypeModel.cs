using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class RoomTypeModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "This field is required :)")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "room type must be between 3 to 50 character")]
        public required string TypeName { get; set; }
    }
}
