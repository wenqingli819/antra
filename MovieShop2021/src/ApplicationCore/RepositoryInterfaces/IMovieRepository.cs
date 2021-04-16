﻿using System;
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

        Task<IEnumerable<Movie>> GetMoviesByGenreId(int genreId);

        Task<double> GetAvgRatingByMovieId(int id);

        Task<Movie> GetMovieDetailById(int id);

        Task<IEnumerable<Movie>> GetMoviesByCast(int castId);
    }
}
