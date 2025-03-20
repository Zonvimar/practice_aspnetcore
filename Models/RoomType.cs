using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RoomType
    {
        [Key]
        public int idRoomType { get; set; }

        [Required]
        [StringLength(100)]
        public string? name { get; set; }

        public ICollection<Service>? services { get; set; }
    }
}
