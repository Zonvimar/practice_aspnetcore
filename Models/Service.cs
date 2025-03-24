using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Service
    {
        [Key]
        public int idService { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [StringLength(50, ErrorMessage = "Название не может превышать 50 символов.")]
        public string name { get; set; }

        [StringLength(255, ErrorMessage = "Описание не может превышать 255 символов.")]
        public string? description { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public int idCategory { get; set; }

        [ForeignKey("idCategory")]
        public Category? Category { get; set; } // Делаем необязательным

        [Required(ErrorMessage = "Поле 'Сотрудник' обязательно для заполнения.")]
        public int idEmployee { get; set; }

        [ForeignKey("idEmployee")]
        public Employee? Employee { get; set; } // Делаем необязательным

        [Required(ErrorMessage = "Поле 'Тип комнаты' обязательно для заполнения.")]
        public int idRoom { get; set; }

        [ForeignKey("idRoom")]
        public RoomType? RoomType { get; set; } // Делаем необязательным

        public int? idPromotion { get; set; } // Уже nullable

        [ForeignKey("idPromotion")]
        public Promotion? Promotion { get; set; } // Делаем необязательным

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public int duration { get; set; }

        public int? idClientGroup { get; set; } // Уже nullable

        [ForeignKey("idClientGroup")]
        public ClientGroup? ClientGroup { get; set; } // Делаем необязательным
    }
}