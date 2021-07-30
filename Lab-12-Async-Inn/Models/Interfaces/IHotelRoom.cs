using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Interfaces
{
    interface IHotelRoom
    {

        // CREATE
        Task<HotelRoom> Create(HotelRoom hotelRoom);

        // GET ALL
        Task<List<HotelRoom>> GetHotelRooms();

        // GET ONE BY ID
        Task<HotelRoom> GetHotelRoom(int id);

        // UPDATE
        Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom hotelRoom);

        // DELETE
        Task Delete(int id);

    }
}
