using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.DTO
{
    public class LoginDTO
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
