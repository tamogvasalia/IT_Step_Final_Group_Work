using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("RoomTypes")]
[Index(nameof(TypeName),IsDescending =new bool[] {true})]
public class RoomType:BaseEntity
{
    [Required]
    [StringLength(50,MinimumLength =3,ErrorMessage ="room type must be between 3 to 50 character")]
    public required string TypeName { get; set; }
    public virtual IEnumerable<Room> Rooms { get; set; }
}