using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace Infrastructure.Helpers
{
    public class MovieShopMappingProfile : Profile
    {
        public MovieShopMappingProfile()
        {
            CreateMap<Movie, MovieCardResponseModel>();
            CreateMap<Cast, CastDetailsResponseModel>()
                .ForMember(c => c.MovieCardResponseModels, 
                    opt => 
                        opt.MapFrom(src => GetMoviesForCast(src.MovieCasts)));

            CreateMap<Movie, MovieDetailsResponseModel>()
                .ForMember(md => md.Casts,
                    opt =>
                        opt.MapFrom(src => GetCasts(src.MovieCasts)));


        }

        private static List<MovieDetailsResponseModel.CastResponseModel> GetCasts(IEnumerable<MovieCast> srcMovieCasts)
        {
            var movieCast = new List<MovieDetailsResponseModel.CastResponseModel>();
            foreach (var cast in srcMovieCasts)
                movieCast.Add(new MovieDetailsResponseModel.CastResponseModel
                {
                    Id = cast.CastId,
                    Gender = cast.Cast.Gender,
                    Name = cast.Cast.Name,
                    ProfilePath = cast.Cast.ProfilePath,
                    TmdbUrl = cast.Cast.TmdbUrl,
                    Character = cast.Character
                });

            return movieCast;
        }

        private List<MovieCardResponseModel> GetMoviesForCast(IEnumerable<MovieCast> srcMovieCasts)
        {
            var castMovies = new List<MovieCardResponseModel>();
            foreach (var movie in srcMovieCasts)
                castMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    PosterUrl = movie.Movie.PosterUrl,
                    Title = movie.Movie.Title
                });

            return castMovies;
        }


    }
}
