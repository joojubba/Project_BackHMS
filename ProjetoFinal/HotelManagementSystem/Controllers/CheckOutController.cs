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
        //aqui pego a uh e vejo qm ta nela
        [HttpGet]
        [Route("{roomNumber}")]
        public async Task<IActionResult> getAllAsync(
        [FromServices] Context context,
        [FromRoute] int roomNumber
            )
        {
            var reservations = await context.Reservations
               .Include(r => r.Room)
               .FirstOrDefaultAsync(r => r.Room.RoomNumber == roomNumber && r.ReservationStatus == ReservationStatus.CheckedIn);


            return reservations == null ? NotFound() : Ok(reservations);
        }
        //aq consigo dar o out com o num da uh
        [HttpPost]
        [Route("{roomNumber}")]
        public async Task<IActionResult> CheckOutAsync(
        [FromServices] Context context,
        [FromRoute] int roomNumber
)
        {
            var reservations = await context.Reservations
                 .Include(r => r.Room)
                 .FirstOrDefaultAsync(r => r.Room.RoomNumber == roomNumber && r.ReservationStatus == ReservationStatus.CheckedIn);

            if (reservations == null)
                return NotFound("No guest checked in to this room!");

            reservations.ReservationStatus = ReservationStatus.CheckedOut;
            reservations.Room.RoomAvailable = true;


            await context.SaveChangesAsync();

            return Ok(reservations);
        }
    }
}

