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
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom r)
        {
            _room = r;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var list = await _room.GetRooms();
            return Ok(list);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            Room room = await _room.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var updatedRoom = await _room.UpdateRoom(id, room);


            return Ok(updatedRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {

            await _room.Create(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {

            await _room.Delete(id);

            return NoContent();
        }

        //This is not in John's example or described in the workshop instructions
        //private bool RoomExists(int id)
        //{
        //    return _room.Rooms.Any(e => e.Id == id);
        //}
    }
}
