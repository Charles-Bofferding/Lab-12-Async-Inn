using Lab_12_Async_Inn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Interfaces
{
    public interface IHotel
    {

        // CREATE
        Task<HotelDTO> Create(Hotel hotel);

        // GET ALL
        Task<List<HotelDTO>> GetHotels();

        // GET ONE BY ID
        Task<HotelDTO> GetHotel(int id);

        // UPDATE
        Task<HotelDTO> UpdateHotel(int id, Hotel hotel);

        // DELETE
        Task Delete(int id);

    }
}
