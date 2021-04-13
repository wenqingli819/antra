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

        public AccountController(IUserService userService)
        {
            _userService = userService;
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

            var registeredUser = _userService.RegisterUser(requestModel);
            return Ok(registeredUser);
        }


    }
}
