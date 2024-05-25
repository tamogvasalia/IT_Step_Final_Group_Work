using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Final_Project;
using Final_Project.Models.Hotel;
using OnlineStore.Core.Entities;

[Table("Rooms")]
public class Room:BaseEntity
{
    public required string Name { get; set; }



    [Range(0,double.MaxValue)]
    public double PricePerDay { get; set; }

    [Required]
    public string PicturePath { get; set; } = "";

    public bool isAvailable { get; set; }

    [Range(0,int.MaxValue)]
    public int maxGuests { get; set; }

    [ForeignKey("RoomType")]
    public long roomTypeId { get; set; }

    [ForeignKey("Hoteli")]
    public long HotelId { get; set; }
    public virtual Hotel Hoteli { get; set; }

    public virtual RoomType RoomType { get; set; }

    public virtual IEnumerable<Booking> books { get; set; }

}
