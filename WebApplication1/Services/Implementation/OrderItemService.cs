using ResturanrtManagement.Models;
using ResturanrtManagement.Repositories.Interfaces;
using ResturanrtManagement.Services.Interfaces;

namespace ResturanrtManagement.Services.Implementation
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IGenericRepository<OrderItem> _repo;

        public OrderItemService(IGenericRepository<OrderItem> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<OrderItem?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task CreateAsync(OrderItem item)
        {
            await _repo.AddAsync(item);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem item)
        {
            _repo.Update(item);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item != null)
            {
                _repo.Remove(item);
                await _repo.SaveChangesAsync();
            }
        }
    }
}
