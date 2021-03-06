using Lab_12_Async_Inn.Data;
using Lab_12_Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Services
{
    public class RoomService : IRoom
    {

        //Set up the context to link to DB
        private AsyncInnDbContext _context;
        //Workshop instructions say to go with StudentRepository instead of StudentService but I am
        //Following JOhn's example
        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //Task 1 of 5, Create Single Room
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        //Task 2 of 5, return all rooms stored in DB
        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms
              .Include(c => c.RoomAmenities)
              .ThenInclude(e => e.Amenity)
              .ToListAsync();
        }

        //Task 3 of 5, reutrn Room with chosen ID
        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms
              .Include(c => c.RoomAmenities)
              .ThenInclude(e => e.Amenity)
              .FirstOrDefaultAsync(s => s.Id == id);
        }

        //Task 4 of 5, Update Room at ID to input amenity
        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        //Task 5 of 5, Delete DB Room entry with given ID
        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new()
            {
                RoomId = roomId,
                AmenityId = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new()
            {
                RoomId = roomId,
                AmenityId = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
