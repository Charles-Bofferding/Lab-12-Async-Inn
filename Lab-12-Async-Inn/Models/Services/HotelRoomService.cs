using Lab_12_Async_Inn.Data;
using Lab_12_Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Services
{
    public class HotelRoomService : IHotelRoom
    {

        //Set up the context to link to DB
        private AsyncInnDbContext _context;

        public HotelRoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //Task 1 of 5, Create Single HotelRooms
        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        //Task 2 of 5, return all HotelRooms stored in DB
        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _context.HotelRooms
              .Include(c => c.Hotel)
              .ThenInclude(e => e.HotelRooms)
              .ToListAsync();
        }

        //Task 3 of 5, reutrn HotelRoom with chosen ID
        public async Task<HotelRoom> GetHotelRoom(int id)
        {
            return await _context.HotelRooms
              .Include(c => c.Hotel)
              .ThenInclude(e => e.HotelRooms)
              .FirstOrDefaultAsync(s => s.RoomId == id);
        }

        //Task 4 of 5, Update HotelRoom at ID
        public async Task<HotelRoom> UpdateHotelRoom(int id, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        //Task 5 of 5, Delete DB Room entry with given ID
        public async Task Delete(int id)
        {
            HotelRoom hotelRoom = await GetHotelRoom(id);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


    }
}
