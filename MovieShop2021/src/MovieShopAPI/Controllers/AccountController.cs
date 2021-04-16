using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserDetailsById(id);
            return Ok(user);
        }


        [HttpGet]
        public async Task<IActionResult> EmailExists(string email)
        {
            var user = await _userService.GetUserDetailsByEmail(email);
            return Ok(user == null ? new { emailExists = false } : new { emailExists = true });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");
            }

            var registeredUser = await _userService.RegisterUser(requestModel);
            return Ok(registeredUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequestModel model)
        {
            var user = await _userService.ValidateUser(model.Email, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var jwtToken = _jwtService.GenerateToken(user);
            // generate a JWT token and send it to Client
            return Ok(new { token = jwtToken });
        }

    }
}
