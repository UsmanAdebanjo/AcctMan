using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcctMan.Domain.Abstract
{
    public interface IGenericRepository<T, TKey> where T : IEntity<TKey>
    {
        Task<T> GetAsync(TKey key);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);


        Task AddAsync(T entity);
        Task AddManyAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);

        Task Delete(T entity);
        Task Delete(IEnumerable<T> entities);



    }

}
