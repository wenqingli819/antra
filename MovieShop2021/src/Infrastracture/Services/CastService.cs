using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace Infrastructure.Services
{
    public class CastService: ICastService
    {
        private readonly ICastRepository _castRepository;
        private readonly IMapper _mapper;
        public CastService(ICastRepository castRepository, IMapper mapper)
        {
            _castRepository = castRepository;
            _mapper = mapper;
        }


        public async Task<MovieDetailsResponseModel.CastResponseModel> GetCastDetailByMovieId(int id)
        {
            // from MovieCard get movieId, then use movieId to match the movieId in MovieCast 
            // then get casts from the MovieCast
            // casts -> castid, name, tmburl, etc
            var cast = await _castRepository.GetByIdAsync(id);
            if (cast == null)
            {
                throw new NotFoundException("Cast", id);
            }

            var response = new MovieDetailsResponseModel.CastResponseModel();
            response.Id = cast.Id;
            response.Name = cast.Name;
            response.ProfilePath = cast.ProfilePath;
            response.TmdbUrl = cast.TmdbUrl;
            //response.Character = cast.MovieCasts.
            return response;
        }
    }
}

