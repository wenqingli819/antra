using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> Get30HighestGrossing();
        Task CreateMovie(MovieCreateRequestModel model);

        Task<List<MovieCardResponseModel>> GetMoviesByGenre(int id);



       Task<double> GetAvgRatingByMovieId(int id);

        Task<MovieDetailsResponseModel> GetMovieDetailByMovie(int id);


    }
}