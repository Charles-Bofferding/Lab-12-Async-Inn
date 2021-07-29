using Lab_12_Async_Inn.Data;
using Lab_12_Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Services
{
    public class HotelService : IHotel
    {

        //Set up the context to link to DB
        private AsyncInnDbContext _context;
        //Workshop instructions say to go with StudentRepository instead of StudentService but I am
        //Following JOhn's example
        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //Task 1 of 5, Create Single Amenity
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        //Task 2 of 5, return all amenities stored in DB
        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        //Task 3 of 5, reutrn amenity with chosen ID
        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        //Task 4 of 5, Update amenity at ID to input amenity
        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        //Task 5 of 5, Delete DB Amenity entry with given ID
        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
