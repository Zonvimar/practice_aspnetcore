using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        public int idEmployee { get; set; }

        [Required]
        [StringLength(200)]
        public string? fullName { get; set; }

        public ICollection<Service>? services { get; set; }
    }
}
