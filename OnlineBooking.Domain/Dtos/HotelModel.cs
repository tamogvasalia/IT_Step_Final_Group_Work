using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class HotelModel
    {
        public long Id { get; set; }//for identity

        [Required(ErrorMessage ="This field is required :)")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name is not Valid")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required :)")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Address must be  between  3-30 character")]
        public required string Address { get; set; }
       
        [Required(ErrorMessage = "This field is required :)")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "City name must be  between  3-30 character")]
        public required string City { get; set; }

        [Required(ErrorMessage = "This field is required :)")]
        public required string PicturePath { get; set; }

        public virtual IEnumerable<Room> Rooms { get; set; }

    }
}
