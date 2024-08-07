using AcctMan.Domain.Abstract;
using AcctMan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcctMan.Infrastructure.Repositories
{

    public class GenericRepository<T, TKey> : IGenericRepository<T,TKey> where T: class, IEntity<TKey>
    {
        private readonly AcctManDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AcctManDbContext context, DbSet<T> dbset)
        {
            _context=context;
            _dbSet=dbset;   
        }


        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            
        }

        public async Task AddManyAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public Task Delete(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
          return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           var result= await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
           var result = await _context.Set<T>().Where(filter).ToListAsync<T>();
            return result;
        }

        public async Task<T> GetAsync(TKey key)
        {
           var result = await _context.Set<T>().FindAsync(key);
            return result;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var entityInDb = _dbSet.Where(filter);
                var result = await _context.Set<T>().FindAsync(entityInDb);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        
        public Task UpdateAsync(T entity)
        {

            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        Task IGenericRepository<T, TKey>.Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}
