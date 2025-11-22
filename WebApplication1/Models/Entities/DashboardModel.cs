namespace ResturanrtManagement.Models.Entities
{
    public class DashboardModel
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int FreeTables { get; set; }
        public int SeatedTables { get; set; }
        public int ReservedTables { get; set; }
        public int NeedsCleaningTables { get; set; }

        public IEnumerable<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public IEnumerable<Table> Tables { get; set; } = new List<Table>();
        public IEnumerable<Order> RecentOrders { get; set; } = new List<Order>();
    }
}
