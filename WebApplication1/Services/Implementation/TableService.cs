using ResturanrtManagement.Models;
using ResturanrtManagement.Repositories.Interfaces;
using ResturanrtManagement.Services.Interfaces;

namespace ResturanrtManagement.Services.Implementation
{
    public class TableService : ITableService
    {
       private readonly IGenericRepository<Table> _tableRepository;

        public TableService(IGenericRepository<Table> tablerepository)
        {
            _tableRepository = tablerepository;
        }

        public async Task<IEnumerable<Table>> GetAllAsync() => await _tableRepository.GetAllAsync();
        public async Task<Table?> GetByIdAsync(int id) => await _tableRepository.GetByIdAsync(id);

        public async Task CreateAsync(Table table)
        {
            await _tableRepository.AddAsync(table);
            await _tableRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Table table)
        {
            _tableRepository.Update(table);
            await _tableRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table != null)
            {
                _tableRepository.Remove(table);
                await _tableRepository.SaveChangesAsync();
            }
        }

         async Task<IEnumerable<Table>> ITableService.GetAllAsync()
        {
            return await _tableRepository.GetAllAsync();
        }

        async Task<Table?> ITableService.GetByIdAsync(int id)
        {
            return await _tableRepository.GetByIdAsync(id);
        }

       
    }
}
