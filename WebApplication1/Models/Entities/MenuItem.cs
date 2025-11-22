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

        [Column(TypeName = "decimal(18, 2)")] // Ensure precise currency storage
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } // e.g., Appetizer, Main Course, Dessert

        public bool IsAvailable { get; set; } = true;

        // Navigation Property: One-to-Many relationship with OrderItem
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
