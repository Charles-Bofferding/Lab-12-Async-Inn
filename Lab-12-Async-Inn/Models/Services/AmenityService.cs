using Lab_12_Async_Inn.Data;
using Lab_12_Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_12_Async_Inn.Models.Services
{
    public class AmenityService : IAmenity
    {
        //Set up the context to link to DB
        private AsyncInnDbContext _context;
        //Workshop instructions say to go with StudentRepository instead of StudentService but I am
        //Following JOhn's example
        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //Task 1 of 5, Create Single Amenity
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        //Task 2 of 5, return all amenities stored in DB
        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities
              .Include(c => c.RoomAmenities)
              .ThenInclude(e => e.Room)
              .ToListAsync();
        }

        //Task 3 of 5, reutrn amenity with chosen ID
        public async Task<Amenity> GetAmenity(int id)
        {
            return await _context.Amenities
              .Include(c => c.RoomAmenities)
              .ThenInclude(e => e.Room)
              .FirstOrDefaultAsync(s => s.Id == id);
        }

        //Task 4 of 5, Update amenity at ID to input amenity
        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }

        //Task 5 of 5, Delete DB Amenity entry with given ID
        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
