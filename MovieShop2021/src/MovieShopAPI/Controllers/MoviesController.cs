using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Routing;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<IActionResult> GetAllMovies([FromQuery] int pageSize = 30, [FromQuery] int page = 1,
        //    string title = "")
        //{
        //    var movies = await _movieService.GetMoviesByPagination(pageSize, page, title);
        //    return Ok(movies);
        //}

        [HttpGet]
        [Route("{id:int}", Name = "GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetAvgRatingByMovieId(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprevenue")]   //attribute based routing 
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.Get30HighestGrossing();
            if (!movies.Any())
            {
                return NotFound("We did not find any movies");
            }

            return Ok(movies); // built-in. automatically convert to JSON

            // System.Text.Json in .Net Core 3
            // previous versions of .NET 1,2 and previous older .NET Framework  => Nuget Newtonsoft (3rd party lib)
            // Serialization : convert C# objects into JSON objects
            // De-Serialization : convert  JSON objects into C# objects
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId);
            return Ok(movies);
        }

    }
}
