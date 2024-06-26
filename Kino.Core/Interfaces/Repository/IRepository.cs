﻿using System.Linq.Expressions;

namespace Kino.Core.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> GetAsync(int id);
        public Task<IEnumerable<TEntity>> GetAllAsync(int count = 0);
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, int count = 0);
        public Task<bool> AddAsync(TEntity entity);
        public Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);
        public Task<bool> AnyAsync();
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<bool> RemoveAsync(TEntity entity);
        public Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
        public Task<bool> UpdateAsync(TEntity entity);
    }
}
