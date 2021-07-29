using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab_12_Async_Inn.Data;
using Lab_12_Async_Inn.Models;
using Lab_12_Async_Inn.Models.Interfaces;

namespace Lab_12_Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity a)
        {
            _amenity = a;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            var list = await _amenity.GetAmenities();
            return Ok(list);
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            Amenity amenity = await _amenity.GetAmenity(id);

            if (amenity == null)
            {
                return NotFound();
            }

            return amenity;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }

            var updatedAmenity = await _amenity.UpdateAmenity(id, amenity);
           

            return Ok(updatedAmenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {

            await _amenity.Create(amenity);

            return CreatedAtAction("GetAmenity", new { id = amenity.Id }, amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {

            await _amenity.Delete(id);

            return NoContent();
        }

        //This is not in John's example or described in the workshop instructions
        //private bool AmenityExists(int id)
        //{
        //    return _amenity.Amenities.Any(e => e.Id == id);
        //}
    }
}
