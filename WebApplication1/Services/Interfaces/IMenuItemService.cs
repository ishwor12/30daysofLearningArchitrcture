using ResturanrtManagement.Models;

namespace ResturanrtManagement.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(int id);
        Task CreateAsync(MenuItem item);
        Task UpdateAsync(MenuItem item);
        Task UpdatePriceAsync(int id, decimal newPrice);
        Task DeleteAsync(int id);
    }
}
