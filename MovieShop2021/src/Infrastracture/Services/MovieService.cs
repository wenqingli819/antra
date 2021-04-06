﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;

        }

        public Task CreateMovie(MovieCreateRequestModel model)
        {
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

        public async Task<double> GetAvgRatingByMovie(int id)
        {
            var avgRating = await _movieRepository.GetAvgRatingByMovieId(id);
            return avgRating;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetailByMovie(int id)
        {
            var movieDetail = await _movieRepository.GetMovieDetailByMovieId(id);
            if (movieDetail == null) throw new NotFoundException("Movie", id);
            var response = _mapper.Map<MovieDetailsResponseModel>(movieDetail);    //response=null
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
                        Id = movie.MovieId,
                        Title = movie.Movies.Title,
                        PosterUrl = movie.Movies.PosterUrl
                    });
            }
            return result;
        }


        //public Task CreateMovie(MovieCreateRequestModel model)
        //{
        // take model and convert it to Movie Entity and send it to repository
        // if repository saves successfully return true/id:2
        //}
    }
}
