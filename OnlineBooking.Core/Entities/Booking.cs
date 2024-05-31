using OnlineStore.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Step_Final;

[Table("Bookings")]
public class Booking: BaseEntity
{

    [ForeignKey("Room")]
    public long RoomId { get; set; }

    [ForeignKey("User")]
    public required string UserID { get; set; }

    [Required]
    public DateTime checkInTime { get; set; }

    [Required]
    public DateTime checkOutTime { get; set; }

    [Range(0,double.MaxValue)]
    public double totalPrice { get; set; } = 0;

    public virtual Room Room { get; set; }

    public virtual User user { get; set; }

}
