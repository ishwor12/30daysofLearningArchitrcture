namespace ResturanrtManagement.Models.Enum
{
    public enum  OrderStatus
    {
        Pending,   // Order is being taken
        Confirmed, // Order sent to kitchen/bar
        InProgress,// Food/Drinks are being prepared
        ReadyForPickup, // Waitstaff to collect food
        Delivered, // Served to the table
        Paid,      // Check has been settled
        Canceled   // Order was canceled
    }
}
