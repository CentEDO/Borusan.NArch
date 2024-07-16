using Application.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfBaseRepository<TEntity, TId, TContext> : IBaseRepository<TEntity, TId>,
        IAsyncRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfBaseRepository(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken=default)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.Now;
            //Context.Remove(entity); Hard Delete
            Context.Update(entity);
        }

        public  async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.DeletedDate = DateTime.Now;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;


        }

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().Where(entity => !entity.DeletedDate.HasValue).ToList();
        }

        public TEntity? GetById(TId id)
        {
            return Context.Set<TEntity>().FirstOrDefault(entity=>entity.Id.Equals(id) && !entity.DeletedDate.HasValue);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();

            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }


        public TEntity Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedDate = DateTime.Now;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.Id.Equals(id) && !entity.DeletedDate.HasValue);
        }


        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return await queryable.ToListAsync();
        }
    }
}
