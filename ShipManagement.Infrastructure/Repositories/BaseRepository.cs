using Microsoft.EntityFrameworkCore;
using ShipManagement.Domain.Entities;
using ShipManagement.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace ShipManagement.Infrasctructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _dbContext;
        private DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> FirstOrDefaulAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>>? where = null, 
            int? skip = null, int? take = null)
        {
            IQueryable<T> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (skip != null)
            {
                query = query.Skip(skip ?? 0);
            }

            if (take != null)
            {
                query = query.Take(take ?? 10);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(where);
            
            return await query.AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? where = null)
        {
            IQueryable<T> query = _dbSet;
            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.CountAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();

            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            T? entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Delete aborted, element not found");
            }
        }

        private async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
