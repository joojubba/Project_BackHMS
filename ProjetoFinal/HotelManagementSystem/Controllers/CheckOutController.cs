using HotelManagementSystem.DataModels;
using HotelManagementSystem.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        [HttpGet]
        [Route("checkout/{reservationId}")]
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
        [Route("checkout/{reservationId}")]
        public async Task<IActionResult> CheckOutAsync(
        [FromServices] Context context,
        [FromRoute] int reservationId
)
        {
            var reservations = await context.Reservations
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (reservations == null)
                return NotFound("Reservation not found!");

            reservations.ReservationStatus = ReservationStatus.CheckedOut;
            reservations.Room.RoomAvailable = true;


            await context.SaveChangesAsync();

            return Ok(reservations);
        }
    }
}

