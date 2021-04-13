using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;


namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;


        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }

        public Task CreateMovie(MovieCreateRequestModel model)
        {
            // take model and convert it to Movie Entity and send it to repository
            // if repository saves successfully return true/id:2
            throw new NotImplementedException();
        }

        public async Task<List<MovieCardResponseModel>> Get30HighestGrossing()
        {
            var movies = await _movieRepository.GetTop30HighestGrossingMovies();
            var result = new List<MovieCardResponseModel>();
            foreach (var movie in movies)  // convert IEnumerable<Movie> to List<MovieCardResponseModel>
            {
                result.Add(
                    new MovieCardResponseModel()
                    {
                        Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl
                    });
            }
            return result;
        }


        public async Task<double> GetAvgRatingByMovieId(int id)
        {
            var avgRating = await _movieRepository.GetAvgRatingByMovieId(id);
            return avgRating;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetailByMovie(int id)
        {
            var movieDetail = await _movieRepository.GetMovieDetailById(id);

            if (movieDetail == null) throw new NotFoundException("Movie", id);

            // for genre
            var genres = new List<GenreModel>();
            foreach (var genre in movieDetail.Genres)
            {
                genres.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            // for cast detail
            var casts = new List<CastResponseModel>();
            foreach (var item in movieDetail.MovieCasts)
            {
                casts.Add(new CastResponseModel
                {
                    Id = item.Casts.Id,
                    Name = item.Casts.Name,
                    Gender = item.Casts.Gender,
                    ProfilePath = item.Casts.ProfilePath,
                    Character = item.Character
                });
            }


            // for movie facts +genres + cast detail
            var response = new MovieDetailsResponseModel()
            {
                Id = movieDetail.Id,
                Title = movieDetail.Title,
                PosterUrl = movieDetail.PosterUrl,
                BackdropUrl = movieDetail.BackdropUrl,
                Rating = movieDetail.Rating,
                Overview = movieDetail.Overview,
                Tagline = movieDetail.Tagline,
                Budget = movieDetail.Budget,
                Revenue = movieDetail.Revenue,
                ImdbUrl = movieDetail.ImdbUrl,
                TmdbUrl = movieDetail.TmdbUrl,
                ReleaseDate = movieDetail.ReleaseDate,
                RunTime = movieDetail.RunTime,
                Price = movieDetail.Price,
                Genres = genres,
                Casts = casts
            };

            return response;
        }


        public async Task<List<MovieCardResponseModel>> GetMoviesByGenre(int id)
        {
            var movies = await _movieRepository.GetMoviesByGenreId(id);
            var result = new List<MovieCardResponseModel>();
            foreach (var movie in movies)  
            {
                result.Add(
                    new MovieCardResponseModel()
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        PosterUrl = movie.PosterUrl
                    });
            }
            return result;
        }


    }
}
