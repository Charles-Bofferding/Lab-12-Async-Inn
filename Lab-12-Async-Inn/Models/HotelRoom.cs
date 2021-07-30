using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models
{
    public class HotelRoom
    {


        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        // Navigation Properties
        // Specifies our linkages between the tables
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }

    }
}
