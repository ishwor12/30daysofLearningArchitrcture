using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturanrtManagement.Models
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } 

        public bool IsAvailable { get; set; } = true;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
