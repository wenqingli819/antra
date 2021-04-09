using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;


namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // we want to show blank page with empty form 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // revieve movie information from view then submit
        [HttpPost]
        public IActionResult Create(MovieCreateRequestModel model)
        {
            _movieService.CreateMovie(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Genre(int id)
        {
            var movies = await _movieService.GetMoviesByGenre(id);
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // call movie service to call the details of the movie that includes details, cast, and rating
            var details = await _movieService.GetMovieDetailByMovie(id);
            //var details = await _movieService.GetMovieDetailByMovie2(id);
            return View(details);
        }
    }
}
