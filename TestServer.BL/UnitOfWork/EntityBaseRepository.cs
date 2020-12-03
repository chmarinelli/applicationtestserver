using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestServer.Core;
using TestServer.Core.Exceptions;
using TestServer.Core.Extensions;
using TestServer.DM.Context;

namespace TestServer.BL.UnitOfWork
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private readonly TestServerContext _context;
        public DbSet<T> _set;
        public FluentValidation.IValidator<T> _validator;

        public EntityBaseRepository(TestServerContext context,
                                    FluentValidation.IValidator<T> validator)
        {
            _context = context;
            _set = context.Set<T>();
            _validator = validator;
        }

        public virtual async Task AddAsync(T entity)
        {
            var results = _validator.Validate(entity);
            if (!results.IsValid) throw new ValidationException(results.Errors.ToMessage());

            await _set.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(T[] entities)
        {
            foreach (var entity in entities)
            {
                var results = _validator.Validate(entity);
                if (!results.IsValid) throw new ValidationException(results.Errors.ToMessage());
            }
            await _set.AddRangeAsync(entities);
        }

        public virtual async Task<T> FindAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) throw new NotFoundException($"\"{typeof(T).Name}\" ({id})");

            return entity;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set.Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsNoTracking();
        }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual async Task SoftDeleteAsync(int key)
        {
            var entity = await FindAsync(key);

            EntityEntry dbEntityEntry = _context.Entry(entity);
            entity.IsDeleted = true;
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            var results = _validator.Validate(entity);
            if (!results.IsValid) throw new ValidationException(results.Errors.ToMessage());

            _set.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            var results = _validator.Validate(entity);
            if (!results.IsValid) throw new ValidationException(results.Errors.ToMessage());

            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
