using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;

            // skip, take in Pagination
            // PageSize = 20
            // 1-20, 21-40, 41-60
            // 1 skip(PageNum-1).take(20)s
            // 2 skip(PageNum-1) * PageSize
            // 3 skip(3-1) * PageSize
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreId(int genreId)
        {
            var count = await _dbContext.Genres
                .Where(g => g.Id == genreId)
                .Include(g => g.Movies)
                .SelectMany(g => g.Movies)
                .CountAsync();

            if (count == 0) throw new NotFoundException("NO Movies found for this genre");


            var movies = await _dbContext.Genres
                .Include(g => g.Movies)
                .Where(g => g.Id == genreId)
                .SelectMany(g => g.Movies)
                .OrderByDescending(m => m.Revenue)
                //.Skip((page - 1) * pageSize).Take(pageSize)
                .ToListAsync();

            return movies;
        }

        public async Task<double> GetAvgRatingByMovieId(int movieId)
        {
            var avgRating = await _dbContext.Reviews
                .Where(r => r.MovieId == movieId)
                .DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating);
            return (double) avgRating;

        }


        public async Task<Movie> GetMovieDetailById(int id)
        {
            var movie = await _dbContext.Movies
                .Where(m => m.Id == id)
                .Include(mg => mg.Genres)
                .Include(m => m.MovieCasts)
                .ThenInclude(mc => mc.Casts)
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                throw new NotFoundException("Movie Not found");
            }

            var avgRating = await _dbContext.Reviews
                .Where(r => r.MovieId == id)
                .DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating);
            if (avgRating > 0) movie.Rating = avgRating;

            return movie;
        }


        public async Task<IEnumerable<Movie>> GetMoviesByCast(int castId)
        {
            return await _dbContext.Casts
                .Where(c => c.Id == castId)
                .SelectMany(c => c.MovieCasts)
                .Select(mc => mc.Movies)
                .OrderByDescending(m => m.Revenue)
                .ToListAsync();
        }

    }
}

