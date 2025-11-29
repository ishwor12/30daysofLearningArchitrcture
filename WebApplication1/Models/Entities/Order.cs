using ResturanrtManagement.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResturanrtManagement.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime DateTimePlaced { get; set; } = DateTime.UtcNow;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; } = 0.00m;

        // Foreign Key to Table (One-to-One with Table)
        public int TableId { get; set; }
        [ForeignKey("TableId")]
        public Table? Table { get; set; }

        // Foreign Key to Waitstaff (User)
        // Assuming you will create a 'User' model later with a primary key of 'UserId'
        public int UserId { get; set; }
        // public User Waitstaff { get; set; } // Uncomment when User model is available

        // Navigation Property: One-to-Many relationship with OrderItem
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
