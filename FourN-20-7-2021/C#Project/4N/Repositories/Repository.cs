using FourN.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                set = set.Include(includeProperty);
            }

            return set.Where(predicate);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();

            if (includes != null)
            {
                set = includes(set);
            }

            return set.Where(predicate);
        }



        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var set = Context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                set.Include(includeProperty);
            }

            return set.FindAsync(id);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void Delete(object id)
        {
            var current = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(current);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                set = set.Include(includeProperty);
            }
            return set.SingleOrDefaultAsync(predicate);
        }
        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                set = set.Include(includeProperty);
            }
            return set.FirstOrDefaultAsync(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();

            if (includes != null)
            {
                set = includes(set);
            }
            return set.FirstOrDefaultAsync(predicate);
        }
        public IQueryable<TEntity> BuildQuery(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> set = Context.Set<TEntity>();
            return set.Where(predicate);
        }
    }
}
