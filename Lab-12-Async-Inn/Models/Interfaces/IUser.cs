using Microsoft.AspNetCore.Mvc.ModelBinding;
using Lab_12_Async_Inn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Interfaces
{
    public class IUser
    {

        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Login(string username, string password);

    }

}
