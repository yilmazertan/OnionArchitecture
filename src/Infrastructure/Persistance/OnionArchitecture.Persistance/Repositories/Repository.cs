using LinqKit;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities.Common;
using OnionArchitecture.Persistance.Context;
using System.Linq.Expressions;
namespace OnionArchitecture.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class,  IEntity, new()
    {

        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        
        
 
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await(predicate == null ? _context.Set<T>().CountAsync() : _context.Set<T>().CountAsync(predicate));
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Remove(entity); });
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> GetAllAsyncV2(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetAsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = query.Where(predicate);

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<T> GetAsyncV2(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IList<T>> SearchAsync(IList<Expression<Func<T, bool>>> predicates, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicates.Any())
            {
                var predicateChain = PredicateBuilder.New<T>();
                foreach (var predicate in predicates)
                {
                    predicateChain.Or(predicate);
                }

                query = query.Where(predicateChain);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run((() => { _context.Set<T>().Update(entity); }));
            return entity;
        }




        //public async Task<T> AddAsync(T entity)
        //{

        //    EntityEntry<T> entityEntry = await Table.AddAsync(entity);
        //    return entity;
        //}

        //public  IQueryable<T>  GetAll (bool tracking = true)
        //{
        //    var query = Table.AsQueryable();
        //    if (!tracking)
        //        query = query.AsNoTracking();
        //    return    query;
        //}

        //public IQueryable<T>  GetByFilter (Expression<Func<T, bool>> filter, bool tracking = true)
        //{
        //    var query = Table.Where(filter);
        //    if (!tracking)
        //        query = query.AsNoTracking();
        //    return query;
        //}

        //public async Task<T> GetByIdAsync(string id, bool tracking = true)
        //{

        //    var query = Table.AsQueryable();
        //    if (!tracking)
        //        query = Table.AsNoTracking();
        //    return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        //}

        //public bool Remove(T entity)
        //{
        //    EntityEntry<T> entityEntry = Table.Remove(entity);
        //    return entityEntry.State == EntityState.Deleted;
        //}



        //public Task UpdateAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<int> SaveChangesAsync()
        //{
        //  return  await _context.SaveChangesAsync();
        //}

        //public bool RemoveRange(List<T> entity)
        //{
        //    Table.RemoveRange(entity);
        //    return true;
        //}
    }
}
 