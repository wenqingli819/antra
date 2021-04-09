using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequestModel)
        {
            // 1. check whether email exists in db
            var dbUser = await _userRepository.GetUserByEmail(registerRequestModel.Email); //wait from UI
            // 2.1 if exists 
            if (dbUser != null)
            {
                throw new Exception("user already exists, please login");
            }
            // 2.2 new user, continue with hashing
            // create a salt, add salt to the user entered password
            var salt = CreateSalt();
            var hashedPassword = HashPassword(registerRequestModel.Password, salt);
            
            // create user object, save to db
            var user = new User
            {
                FirstName = registerRequestModel.FirstName,
                LastName = registerRequestModel.LastName,
                Email = registerRequestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = registerRequestModel.DateOfBirth
            };

            var createdUser = await _userRepository.AddAsync(user);
            var createdUserResponseModel = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return createdUserResponseModel;
        }


        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string HashPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }


        public async Task<LoginResponseModel> ValidateUser(string email, string password)
        {
            // check db with user email
            var dbUser = await _userRepository.GetUserByEmail(email);

            // if not exist 
            if (dbUser == null) return null;
    

            // if exists, check hashed password
            var hashedPassword = HashPassword(password, dbUser.Salt);
            if (hashedPassword == dbUser.HashedPassword)
            {
                // if user entered a correct password 
                var loginUserResponse = new LoginResponseModel
                {
                    Id = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Email = dbUser.Email
                };
                return loginUserResponse;
            }


            return null;
        }
    }
}
