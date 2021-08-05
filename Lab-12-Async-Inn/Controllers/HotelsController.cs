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
using Lab_12_Async_Inn.Models.DTO;

namespace Lab_12_Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;
        //This should get added in

        public HotelsController(IHotel h)
        {
            _hotel = h;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            var list = await _hotel.GetHotels();
            return Ok(list);
        }

        // GET: api/Hotels/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {

            HotelDTO hotel = await _hotel.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            var updatedHotel = await _hotel.UpdateHotel(id, hotel);


            return Ok(updatedHotel);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {

            await _hotel.Create(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {

            await _hotel.Delete(id);

            return NoContent();
        }

        //This is not in John's example or described in the workshop instructions
        //private bool HotelExists(int id)
        //{
        //    return _hotel.Hotels.Any(e => e.Id == id);
        //}
    }
}
