using Microsoft.EntityFrameworkCore;
using ShipManagement.Domain.Entities;
using ShipManagement.Domain.Interfaces.Repositories;
using System.Linq;
using System.Linq.Expressions;
using System.Xml;

namespace ShipManagement.Test.Core.Repositories
{
    public class BaseRepositoryMock<T> : IBaseRepository<T> where T : BaseEntity
    {
        private List<T> _entities = new List<T>();
        
        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Task.FromResult(_entities.Any(where.Compile()));
        }

        public Task<int> CountAsync(Expression<Func<T, bool>>? where = null)
        {
            return Task.FromResult(_entities.Count(where.Compile()));
        }

        public Task<T> CreateAsync(T entity)
        {
            _entities.Add(entity);

            return Task.FromResult(entity);
        }

        public Task DeleteAsync(Guid id)
        {
            T? entity =  _entities.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Delete aborted, element not found");
            }

            return Task.FromResult(_entities.Remove(entity));
        }

        public Task<T?> FirstOrDefaulAsync(Expression<Func<T, bool>> where)
        {
            return Task.FromResult(_entities.FirstOrDefault(where.Compile()));
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_entities.SingleOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>>? where = null, int? skip = null, int? take = null)
        {
            IEnumerable<T> entities = _entities.ToList();

            if(where != null)
            {
                entities = entities.Where(where.Compile()).ToList();
            }

            if(skip != null)
            {
                entities = entities.Skip(skip ?? 0).ToList();
            }

            if (take != null)
            {
                entities = entities.Take(take ?? 0).ToList();
            }

            return Task.FromResult(entities);
        }

        public Task<T> UpdateAsync(T entity)
        {
            var index = _entities.FindIndex(x => entity.Id == x.Id);
            if (index == -1)
            {
                throw new KeyNotFoundException("Element not found");
            }
            _entities[index] = entity;

            return Task.FromResult(entity);
        }
    }
}
