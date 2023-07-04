using HotelManagementSystem.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HousekeepingController : ControllerBase
    {
        [HttpGet]
        [Route("{roomNumber}")]
        public async Task<IActionResult> getAllAsync(
        [FromServices] Context context,
        [FromRoute] int roomNumber
           )
        { 
            var rooms = await context
               .Rooms
               .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);

            return rooms == null ? NotFound() : Ok(rooms.Status.ToString());

        }

        [HttpPost]
        [Route("{roomNumber}")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromRoute] int roomNumber,
        [FromBody] RoomStatus status
)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var rooms = await context
                .Rooms
                .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);

            if (rooms == null)
                return NotFound("Room not found!");
            try
            {
                rooms.Status = status;
                await context.SaveChangesAsync();

                return Ok(rooms);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
          
        }
    }
}
