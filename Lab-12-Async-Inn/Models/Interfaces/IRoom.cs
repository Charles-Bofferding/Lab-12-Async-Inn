using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Interfaces
{
    public interface IRoom
    {

        // CREATE
        Task<Room> Create(Room room);

        // GET ALL
        Task<List<Room>> GetRooms();

        // GET ONE BY ID
        Task<Room> GetRoom(int id);

        // UPDATE
        Task<Room> UpdateRoom(int id, Room room);

        // DELETE
        Task Delete(int id);

        //Add Ammenity
        Task AddAmenityToRoom(int roomId, int amenityId);

        //Remove ammenity from room
        Task RemoveAmentityFromRoom(int roomId, int amenityId);

    }
}
