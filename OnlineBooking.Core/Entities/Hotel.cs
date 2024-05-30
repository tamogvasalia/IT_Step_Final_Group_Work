using OnlineStore.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IT_Step_Final.Models.Hotel;

[Table("Hotels")]
public class Hotel:BaseEntity
{
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Hotel Name must be  between  3-30 character")]
    [Required]
    public required string Name { get; set; }

    [StringLength(30, MinimumLength = 3, ErrorMessage = "Address must be  between  3-30 character")]
    [Required]
    public required  string Address { get; set; }
    [Required]
    [StringLength(30,MinimumLength =3,ErrorMessage ="City name must be  between  3-30 character")]
    public required string City { get; set; }

    [Required]
    public required string PicturePath { get; set; } //picture for display

    public virtual IEnumerable<Room> Rooms { get; set; }
}
