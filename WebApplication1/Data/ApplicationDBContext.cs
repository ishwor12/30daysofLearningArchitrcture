using Microsoft.EntityFrameworkCore;
using ResturanrtManagement.Models;

namespace ResturanrtManagement.ApplicationDbContext
{
    // The DbContext is the connection point between  application and the database.
    public class ApplicationDBContext : DbContext
    {
        // Constructor for dependency injection
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        // Define every database tables which is called DbSets)
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Configure the model relationships (Fluent API)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -----------------------------------------------------------------------
            // Configuration for Table and Order Relationship
            // -----------------------------------------------------------------------

            // Configure the One-to-Many Relationship (Historical/Active Orders)
            // A Table can have many Orders.
            modelBuilder.Entity<Table>()
                .HasMany(t => t.Orders) // Maps to the ICollection<Order> Orders property
                .WithOne(o => o.Table) // The inverse navigation property on Order is 'Table'
                .HasForeignKey(o => o.TableId)
                // CRITICAL: Set DeleteBehavior to Restrict to prevent multiple cascade path errors.
                // This means if you delete a Table, you must manually ensure all related Orders are handled first.
                .OnDelete(DeleteBehavior.Restrict);

            // The ambiguous HasOne(t => t.CurrentOrder) configuration has been removed 
            // as the property no longer exists on the Table model.

            // -----------------------------------------------------------------------
            // Configure OrderItem (Many-to-Many via Order and MenuItem)
            // -----------------------------------------------------------------------

            // OrderItem <-> Order (Many-to-One)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // If Order is deleted, its OrderItems are deleted.

            // OrderItem <-> MenuItem (Many-to-One)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany(mi => mi.OrderItems)
                .HasForeignKey(oi => oi.ItemId)
                // If a MenuItem is deleted, the corresponding OrderItem FK is set to null.
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
    }
