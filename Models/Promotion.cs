using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace WebApplication1.Models
{
    public class Promotion
    {
        [Key]
        public int idPromotion { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal discount { get; set; }

        public ICollection<Service> services { get; set; }
    }
}
