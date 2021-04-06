using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreModel>> GetAllGenres();
    }
}