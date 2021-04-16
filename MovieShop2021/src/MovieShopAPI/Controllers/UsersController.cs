using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // localhost:4431/api/users/id
        [Authorize]
        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetPurchasedMovies()
        {
            // get all movies purchased by user by calling service
            // var userPurchasedMovies = _userService
            return Ok();

        }
    }
}
