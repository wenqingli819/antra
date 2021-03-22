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
        Task<IEnumerable<FilmCast>> GetByIdAsync(int id);
        Task<IEnumerable<FilmCast>> GetAllAsync();


        Task<bool> InsertAsync(FilmCast item);
        Task<bool> UpdateAsync(FilmCast item, int id);
        Task<bool> DeleteAsync(int id);
    }
}
