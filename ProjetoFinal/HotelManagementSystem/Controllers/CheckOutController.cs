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
        [Route("checkouts")]
        public async Task<IActionResult> getAllAsync([FromServices] Context context)
        {
            var reservations = await context
                .Reservations
                .Include(r => r.Room)
                .Include(p => p.Payment)
                .Where(r => r.ReservationStatus == ReservationStatus.CheckedOut)
                .ToListAsync();

            return reservations == null ? NotFound() : Ok(reservations);
        }
       
        [HttpPost]
        [Route("checkouts/{roomNumber}")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromRoute] int roomNumber
)
        {
            var reservations = await context
                .Reservations
                .Include(r => r.Room)
                .FirstOrDefaultAsync(r => r.Room.RoomNumber == roomNumber && r.ReservationStatus == ReservationStatus.CheckedIn);

            if (reservations == null)
                return NotFound("No hotelguest checked into this room!");
            
            var rooms = await context
                .Rooms
                .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);

            if (rooms == null)
                return NotFound("Room not found!");
         

            reservations.ReservationStatus = ReservationStatus.CheckedOut;
            reservations.Room.RoomAvailable = true;

            reservations.Room = rooms;
           
            reservations.Room.Status = RoomStatus.VacantDirty;

            var statusRoom = rooms.Status;
            var statusReserv = reservations.ReservationStatus;

            var statusRoomString = statusRoom.ToString();
            var statusReservString = statusReserv.ToString();

            await context.SaveChangesAsync();

            return Ok(new { Room = rooms, Status = statusRoomString, ReservationStatus = statusReservString, reservations });
        }
    }
}

