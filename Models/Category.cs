using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int idCategory { get; set; }

        [Required]
        [StringLength(255)]
        public string category { get; set; }


        public ICollection<Service>? services { get; set; }
    }
}
