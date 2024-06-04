using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcctMan.Domain
{
    public interface IGenericRepository<T, TKey> where T: IEntity<TKey>
    {
        Task<T> GetAsync(TKey key);
        Task<T> GetAsync(Expression<Func<T,object>> filter);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);


        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddManyAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        Task DeleteManyAsync(IEnumerable<T> entities);



    }

}
