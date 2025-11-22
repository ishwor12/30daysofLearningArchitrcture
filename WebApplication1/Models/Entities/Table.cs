using ResturanrtManagement.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace ResturanrtManagement.Models
{
  
        public class Table
        {
            [Key]
            public int TableId { get; set; }

            [Required]
            public int TableNumber { get; set; }

            [Required]
            [Range(1, 10)] // Example: Max capacity from 1 to 10 people
            public int MaxCapacity { get; set; }

            [Required]
            public TableStatus Status { get; set; }

            // NAVIGATION PROPERTIES

            // 1. One-to-Many relationship with historical Orders.
            // THIS IS THE PROPERTY THE DbContext CONFIGURATION REQUIRES (modelBuilder.Entity<Table>().HasMany(t => t.Orders))
            public ICollection<Order> Orders { get; set; } = new List<Order>();

           
        }
    
}
