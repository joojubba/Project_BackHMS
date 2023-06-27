using HotelManagementSystem.DataModels;
using HotelManagementSystem.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        [HttpGet]
        [Route("{reservationId}")] 
        public async Task<IActionResult> getAllAsync(
        [FromServices] Context context,
        [FromRoute] int reservationId
            )
        {
            var reservations = await context
                .Reservations
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            return reservations == null ? NotFound() : Ok(reservations);
        }

        [HttpPost]
        [Route("checkin")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromBody] int id
           )
        {
            if (!ModelState.IsValid) return BadRequest();        

            try
            {
             
                var reservations = await context.Reservations
                    .Include(r => r.Room)
                    .FirstOrDefaultAsync(r => r.ReservationId == id);
    
                if (reservations == null)
                    return NotFound("Reservation not found!");
  
                if (!reservations.Room.RoomAvailable)
                    return BadRequest("Room is not available!");

             
                reservations.ReservationStatus = ReservationStatus.CheckedIn;

              
                reservations.Room.RoomAvailable = false;

                await context.SaveChangesAsync();
                return Ok(reservations);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

       
    }
}
