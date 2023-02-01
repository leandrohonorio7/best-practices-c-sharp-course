using Avanade.BestPractices.Infrestructure.Core.Entities;
using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using Avanade.BestPractices.Infrestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Infrestructure.Data.Repositories.Core
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private readonly EntityContext _db;

        public RepositoryBase(EntityContext db)
        {
            _db = db;
        }

        public Task AddAsync(T entity)
        {
            return _db.Set<T>()
               .AddAsync(entity)
               .AsTask();
        }

        public Task AddRangeAsync(List<T> entities)
        {
            return _db.Set<T>()
                .AddRangeAsync(entities);
        }

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>()
                .Where(expression)
                .ToListAsync();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return _db.Set<T>()
                .FindAsync(id)
                .AsTask();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _db.Set<T>()
                .ToListAsync();
        }

        public IQueryable<T> Query()
        {
            return _db.Set<T>();
        }

        public void Remove(T entity)
        {
            _db.Set<T>()
                .Remove(entity);
        }

        public void RemoveRange(List<T> entities)
        {
            _db.Set<T>()
                .RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _db.Set<T>()
                .Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            _db.Set<T>()
                .UpdateRange(entities);
        }
    }
}
