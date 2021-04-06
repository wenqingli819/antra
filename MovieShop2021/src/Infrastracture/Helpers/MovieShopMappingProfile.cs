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
                .ForMember(cd => cd.MovieCardResponseModels, 
                    opt => 
                        opt.MapFrom(src => GetMoviesCasts(src.MovieCasts)));

            CreateMap<Movie, MovieDetailsResponseModel>()
                .ForMember(md => md.Casts,
                    opt =>
                        opt.MapFrom(src => GetCasts(src.MovieCasts)));
                //.ForMember(md => md.Genres, opt
                //    => opt.MapFrom(src => GetMovieGenres(src.MovieGenres)));
        }

        private static List<MovieDetailsResponseModel.CastResponseModel> GetCasts(IEnumerable<MovieCast> srcMovieCasts)
        {
            var movieCast = new List<MovieDetailsResponseModel.CastResponseModel>();
            foreach (var cast in srcMovieCasts)
                movieCast.Add(new MovieDetailsResponseModel.CastResponseModel
                {
                    Id = cast.CastId,
                    Gender = cast.Casts.Gender,
                    Name = cast.Casts.Name,
                    ProfilePath = cast.Casts.ProfilePath,
                    TmdbUrl = cast.Casts.TmdbUrl,
                    Character = cast.Character

                });

            return movieCast;
        }


        // cast -> CastDetailsResponseModel (include MovieCardResponseModels)
        private List<MovieCardResponseModel> GetMoviesCasts(IEnumerable<MovieCast> srcMovieCasts)
        {
            var castMovies = new List<MovieCardResponseModel>();
            foreach (var movie in srcMovieCasts)
            {
                castMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    PosterUrl = movie.Movies.PosterUrl,
                    Title = movie.Movies.Title
                });
            }

            return castMovies;
        }

        //private List<Genre> GetMovieGenres(IEnumerable<MovieGenre> srcGenres)
        //{
        //    var movieGenres = new List<Genre>();
        //    foreach (var genre in srcGenres)
        //    {
        //        movieGenres.Add(new Genre { Id = genre.GenreId, Name = genre.Genres.Name });
        //    }

        //    return movieGenres;
        //}


    }
}
