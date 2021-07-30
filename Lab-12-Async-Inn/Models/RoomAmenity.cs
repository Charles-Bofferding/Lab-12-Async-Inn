using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models
{
    public class RoomAmenity
    {

        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        // Navigation Properties
        // Specifies our linkages between the tables
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }

    }
}
