using ResturanrtManagement.Models;

namespace ResturanrtManagement.Interface
{
    // The Service Interface defines the business operations (BLL)
    public interface IMenuItemService
    {// READ operations
        // Get all items (useful for management/admin view)
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();

        // Get only available items (useful for customer-facing menu view)
        Task<IEnumerable<MenuItem>> GetAvailableMenuItemsAsync();

        // Get single item details
        Task<MenuItem?> GetMenuItemDetailsAsync(int itemId);

        // CREATE operation
        Task CreateMenuItemAsync(MenuItem item);

        // UPDATE operations
        // General update for all properties (used by the Edit POST action)
        Task UpdateMenuItemAsync(MenuItem item);

        // Specialized business operation (e.g., quick price adjustment)
        Task UpdatePriceAsync(int itemId, decimal newPrice);

        // DELETE operation
        Task DeleteMenuItemAsync(int itemId);
    }
}
