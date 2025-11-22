using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturanrtManagement.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        [Range(1, 99, ErrorMessage = "Quantity must be between 1 and 99.")] // Added range validation
        public int Quantity { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; } // e.g., "Extra sauce", "No onions"

        
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        // Foreign Key to MenuItem (Many-to-One)
        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public MenuItem? MenuItem { get; set; }
    }
}
