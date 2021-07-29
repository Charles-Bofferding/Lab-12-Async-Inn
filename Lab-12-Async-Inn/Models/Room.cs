using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models
{
    public class Room
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Layout { get; set; }
        //0 = studio
        //1 = 1 bedroom
        //2 = 2 bedroom
    }
}
