using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class UserSignInModel
    {
        [Required(ErrorMessage ="This field is required")]
        public required string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public required string UserName { get; set; }
    }
}
