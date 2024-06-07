using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.Domain.Dtos
{
    public class BookingModel
    {
        public long Id { get; set; }// for identity entites in MVC

        [Display(Name ="Room Identificator")]
        [Required(ErrorMessage ="This field is required")]
        public long RoomId { get; set; }

        [Display(Name ="Userd Identificator")]
        [Required(ErrorMessage ="This field is required")]
        public string UserID { get; set; }

        [Required(ErrorMessage ="THis field is required :(")]
        public DateTime checkInTime { get; set; }

        [Required(ErrorMessage ="This field is required :(")]
        public DateTime checkOutTime { get; set; }

        [Range(0, double.MaxValue)]
        public double totalPrice { get; set; } = 0;
        public virtual RoomModel Room { get; set; }
    }
}
