using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies();

        Task<IEnumerable<MovieGenre>> GetMoviesByGenreId(int id);

        Task<double> GetAvgRatingByMovieId(int id);

        Task<Movie> GetMovieDetailByMovieId(int id);


    }
}
