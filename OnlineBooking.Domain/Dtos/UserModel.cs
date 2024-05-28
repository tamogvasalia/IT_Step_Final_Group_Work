using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class UserModel
    {
        [Required(ErrorMessage ="Name is required")]
        [StringLength(20,ErrorMessage ="Such Name no exist",MinimumLength =2)]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(20, ErrorMessage = "Such Surname no exist", MinimumLength = 2)]
        public required string LastName { get; set; }

        [Required(ErrorMessage ="Phone Number is required")]
        public required string PhoneNumber { get; set; }

        [Required( ErrorMessage ="Password Is Nececery")]
        public required string Password { get; set; }

        [Required(ErrorMessage ="UserName is not valid")]
        public required string UserName { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
    }
}
