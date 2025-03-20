using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ClientGroup
    {
        [Key]
        public int idClientGroup { get; set; }

        [Required]
        [StringLength(50)]
        public string? name { get; set; }

        public ICollection<Service>? services { get; set; }
    }
}
