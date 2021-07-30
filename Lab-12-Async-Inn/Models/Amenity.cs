using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models
{
    public class Amenity
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //List of Rooms to tie to
        public List<RoomAmenity> RoomAmenities { get; set; }

    }
}
