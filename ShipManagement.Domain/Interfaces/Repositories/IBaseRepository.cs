using ShipManagement.Domain.Entities;
using System.Linq.Expressions;

namespace ShipManagement.Domain.Interfaces.Repositories
{
    public interface IBaseRepository <T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> FirstOrDefaulAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>>? where = null, int? skip = null, int? take = null);
        Task<int> CountAsync(Expression<Func<T, bool>>? where = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> where);
        Task<T> CreateAsync (T entity);
        Task<T> UpdateAsync (T entity);
        Task DeleteAsync(Guid id);        
    }
}
