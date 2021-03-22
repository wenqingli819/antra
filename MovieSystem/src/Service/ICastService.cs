using MovieShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Service
{
    public interface ICastService
    {
        Task<IEnumerable<Cast>> GetByIdAsync(int id);
        Task<IEnumerable<Cast>> GetAllAsync();


        Task<bool> InsertAsync(Cast item);
        Task<bool> UpdateAsync(Cast item, int id);
        Task<bool> DeleteAsync(int id);
    }
}
