using System.Linq.Expressions;

namespace ResturanrtManagement.Repositories.Interfaces
{
    // T must be a class and represent an entity (like MenuItem, Order, Table)
    public interface IGenericRepository<T> where T : class
    {
        // READ operations
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // CREATE operation
        Task AddAsync(T entity);

        // UPDATE operation
        void Update(T entity);

        // DELETE operation
        void Remove(T entity);

        // SAVE changes to the database
        Task<int> SaveChangesAsync();
    }
}
