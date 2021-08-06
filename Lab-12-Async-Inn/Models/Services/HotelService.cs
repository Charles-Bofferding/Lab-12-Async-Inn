using Lab_12_Async_Inn.Data;
using Lab_12_Async_Inn.Models.DTO;
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
        public async Task<HotelDTO> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;

            await _context.SaveChangesAsync();

            //Convert Hotel into HotelDTO
            return await _context.Hotels
                .Select(hotel => new HotelDTO()
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone
                }).FirstOrDefaultAsync(h => h.ID == hotel.Id);
        }

        //Task 2 of 5, return all amenities stored in DB
        public async Task<List<HotelDTO>> GetHotels()
        {
            //Convert Hotel into HotelDTO
            return await _context.Hotels
                .Select(hotel => new HotelDTO()
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone
                }).ToListAsync();
        }

        //Task 3 of 5, reutrn amenity with chosen ID
        public async Task<HotelDTO> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            //Convert Hotel into HotelDTO
            return await _context.Hotels
                .Select(hotel => new HotelDTO()
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone
                }).FirstOrDefaultAsync(h => h.ID == id);
        }

        //Task 4 of 5, Update amenity at ID to input amenity
        public async Task<HotelDTO> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            //Convert Hotel into HotelDTO
            return await _context.Hotels
                .Select(hotel => new HotelDTO()
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone
                }).FirstOrDefaultAsync(h => h.ID == id);
        }

        //Task 5 of 5, Delete DB Amenity entry with given ID
        public async Task Delete(int id)
        {
            //Grab Hotel by Id
            Hotel hotel = await _context.Hotels.FindAsync(id);
            //Set the state to be deleted
            _context.Entry(hotel).State = EntityState.Deleted;
            //Save the changes
            await _context.SaveChangesAsync();
        }

    }
}
