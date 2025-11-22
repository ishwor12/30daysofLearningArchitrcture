using Microsoft.EntityFrameworkCore;
using ResturanrtManagement.ApplicationDbContext;
using ResturanrtManagement.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ResturanrtManagement.Repositories.Implementation
{

    // Implementation of the generic repository 
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDBContext _context;
        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        // --- CREATE ---
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        // --- UPDATE ---
        // EF Core tracks changes, so Update just marks the entity's state as Modified
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        // --- DELETE ---
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        // --- SAVE ---
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
