using Microsoft.AspNetCore.Mvc.ModelBinding;
using Lab_12_Async_Inn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Lab_12_Async_Inn.Models.Interfaces
{
    public interface IUser
    {

        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Login(string username, string password);
        public Task<UserDTO> GetUserAsync(ClaimsPrincipal principal);
    }

}
