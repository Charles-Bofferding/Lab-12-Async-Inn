using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models
{
    public class RoomAmenity
    {
        //So the dotnet needed a primary key to be defined so I put this in here because I am focusing on user stuff and just want it to run
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        // Navigation Properties
        // Specifies our linkages between the tables
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }

    }
}
