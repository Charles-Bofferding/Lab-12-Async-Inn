using Lab_12_Async_Inn.Models.DTO;
using Lab_12_Async_Inn.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Services
{
    
    public class IdentityUserService : IUser
    {

        //Setting up what this service knows about
        private UserManager<ApplicationUser> userManager;

        private JwtTokenService tokenService;

        public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService JwtTokenService)
        {
            userManager = manager;
            tokenService = JwtTokenService;

        }

        public async Task<UserDTO> Login(string username, string password)
        {
            // Check that the user exists in the database
            var user = await userManager.FindByNameAsync(username);

            // Check the password
            if (await userManager.CheckPasswordAsync(user, password))
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await tokenService.GetTokenAsync(user, System.TimeSpan.FromMinutes(15))
                };
            }

            return null;
        }

        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            //Set up the user object to be registered
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            //Try and load it in, return a User DTO if suceeded
            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            //The errors for if the registration of the user failed
            foreach (var error in result.Errors)
            {
                var errorKey =
                  error.Code.Contains("Password") ? nameof(data.Password) :
                  error.Code.Contains("Email") ? nameof(data.Email) :
                  error.Code.Contains("UserName") ? nameof(data.Username) :
                  "";

                modelState.AddModelError(errorKey, error.Description);

            }

            //No userDTO handed back if it failed
            return null;
        }

        // Use a "claim" to get a user
        public async Task<UserDTO> GetUserAsync(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            return new UserDTO
            {
                Id = user.Id,
                Username = user.UserName
            };
        }

    }
}
