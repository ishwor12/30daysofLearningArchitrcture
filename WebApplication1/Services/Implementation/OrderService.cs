using ResturanrtManagement.Models;
using ResturanrtManagement.Repositories.Interfaces;
using ResturanrtManagement.Services.Interfaces;

namespace ResturanrtManagement.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderrepo;

        public OrderService(IGenericRepository<Order> repo)
        {
            _orderrepo = repo;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() => await _orderrepo.GetAllAsync();
        public async Task<Order?> GetByIdAsync(int id) => await _orderrepo.GetByIdAsync(id);

        public async Task CreateAsync(Order order)
        {
            await _orderrepo.AddAsync(order);
            await _orderrepo.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _orderrepo.Update(order);
            await _orderrepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _orderrepo.GetByIdAsync(id);
            if (order != null)
            {
                _orderrepo.Remove(order);
                await _orderrepo.SaveChangesAsync();
            }
        }
    }
}
