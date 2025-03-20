using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Service
    {
        [Key]
        public int idService { get; set; }

        [StringLength(50, ErrorMessage = "Название не может превышать 50 символов.")]
        public string name { get; set; }

        [StringLength(255, ErrorMessage = "Описание не может превышать 255 символов.")]
        public string description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal price { get; set; }

        public int idCategory { get; set; }
        [ForeignKey("idCategory")]
        public Category Category { get; set; }

        public int idEmployee { get; set; }
        [ForeignKey("idEmployee")]
        public Employee Employee { get; set; }

        public int idRoom { get; set; }
        [ForeignKey("idRoom")]
        public RoomType RoomType { get; set; }

        public int? idPromotion { get; set; }
        [ForeignKey("idPromotion")]
        public Promotion Promotion { get; set; }

        public int duration { get; set; }

        public int? idClientGroup { get; set; }
        [ForeignKey("idClientGroup")]
        public ClientGroup ClientGroup { get; set; }
    }
}
