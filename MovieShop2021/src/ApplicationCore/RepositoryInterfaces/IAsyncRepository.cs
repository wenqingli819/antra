using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T:class  //generic constraint
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> ListAllAsync();

        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);

        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);  //optional filter, don't need to can pass or not pass anything. it is not a must, but if the filter is nothing then default is null

        Task<bool> GetExisitAsync(Expression<Func<T, bool>> filter = null); // give an email, tell me if it is exist in the user table

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);    //void

    }
}
