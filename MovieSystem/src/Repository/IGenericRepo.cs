using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();


        Task<bool> InsertAsync(T item);
        Task<bool> UpdateAsync(T item, int id);
        Task<bool> DeleteAsync(int id);
            
    }
    
}
