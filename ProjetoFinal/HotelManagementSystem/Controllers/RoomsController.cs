using HotelManagementSystem.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet]
        [Route("rooms")]
        public async Task<IActionResult> getAllAsync(
        [FromServices] Context context)
        {
            var rooms = await context
                .Rooms
                .AsNoTracking()
                .ToListAsync();

            return rooms == null ? NotFound() : Ok(rooms);
        }

        [HttpGet]
        [Route("rooms/{id}")]
        public async Task<IActionResult> getByIdAsync(
        [FromServices] Context context,
        [FromRoute] int id
            )
        {
            var rooms = await context
                .Rooms
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RoomId == id);

            return rooms == null ? NotFound() : Ok(rooms);
        }

        [HttpGet]
        [Route("rooms/available")]
        public async Task<IActionResult> GetAvailableAsync(
        [FromServices] Context context)
        {
            var availableRooms = await context
                .Rooms
                .Where(r => r.RoomAvailable)
                .ToListAsync();

            return Ok(availableRooms);
        }

        [HttpPost]
        [Route("rooms")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromBody] Room room
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await context.Rooms.AddAsync(room);
                await context.SaveChangesAsync();
                return Created($"api/rooms/{room.RoomId}", room);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        [Route("rooms/{id}")]
        public async Task<IActionResult> PutAsync(
        [FromServices] Context context,
        [FromBody] Room room,
        [FromRoute] int id
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            var r = await context.Rooms
                .FirstOrDefaultAsync(x => x.RoomId == id);
            if (r == null)
                return NotFound("Room not found!");

            try
            {
                r.RoomNumber = room.RoomNumber;
                r.RoomCapacity = room.RoomCapacity;
                r.RoomType = room.RoomType;
                r.RoomAvailable = room.RoomAvailable;
                r.RoomDescription = room.RoomDescription;

                context.Rooms.Update(r);
                await context.SaveChangesAsync();
                return Ok(r);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpDelete]
        [Route("rooms/{id}")]
        public async Task<IActionResult> DeleteAsync(
        [FromServices] Context context,
        [FromRoute] int id
           )
        {
            var r = await context.Rooms
                .FirstOrDefaultAsync(x => x.RoomId == id);

            if (r == null)
                return NotFound("Room not found!");

            try
            {

                context.Rooms.Remove(r);
                await context.SaveChangesAsync();
                return Ok(r);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
