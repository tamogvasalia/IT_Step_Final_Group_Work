using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Core.Entities
{
    public abstract class BaseEntity //following  solid principe
    {
        [Key]
        public  long Id { get; set; }
    }
}
