using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        #region Add
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        #endregion

        #region Find
        Task<List<T>> FindAsync(Expression<Func<T, bool>> expression);
        #endregion

        #region Get
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        #endregion

        #region Update
        void Update(T entity);
        void UpdateRange(List<T> entity);
        #endregion

        #region Remove
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        #endregion

        #region Queryable
        IQueryable<T> Query();
        #endregion
    }
}
