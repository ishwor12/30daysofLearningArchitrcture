using ResturanrtManagement.Models;

namespace ResturanrtManagement.Services.Interfaces
{
    public interface 
        IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task CreateAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
