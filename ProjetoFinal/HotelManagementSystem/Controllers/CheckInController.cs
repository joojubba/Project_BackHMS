﻿using HotelManagementSystem.DataModels;
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
        [Route("checkins")]
        public async Task<IActionResult> getAllAsync([FromServices] Context context)
        {
            var reservations = await context
                .Reservations
                .Include(r => r.Room)
                .Where(r => r.ReservationStatus == ReservationStatus.CheckedIn)
                .ToListAsync();

            return reservations == null ? NotFound() : Ok(reservations);
        }


        //aq consigo dar a entrada em uma uh selecionada
        [HttpPost]
        [Route("checkin")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromQuery] int roomNumber,
        [FromBody] int id

           )
        {
            if (!ModelState.IsValid) return BadRequest();        

            try
            {
             
                var reservations = await context
                    .Reservations
                    .Include(r => r.Room)
                    .FirstOrDefaultAsync(r => r.ReservationId == id);
    
                if (reservations == null)
                    return NotFound("Reservation not found!");

                var room = await context.Rooms
                    .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);

                if (room == null)
                    return NotFound("Room not found!");

                if (!room.RoomAvailable)
                    return BadRequest("Room is not available!");

             
                reservations.ReservationStatus = ReservationStatus.CheckedIn;
                reservations.Room = room;
                reservations.Room.RoomAvailable = false;
                reservations.Room.Status = RoomStatus.OccupiedClean;

                var statusRoom = room.Status;
                var statusReserv = reservations.ReservationStatus;

                // p converter o valor do enum em uma string
                var statusRoomString = statusRoom.ToString();
                var statusReservString = statusReserv.ToString();

                // retorno a string como parte da resposta

                await context.SaveChangesAsync();
                return Ok(new { Room = room, Status = statusRoomString, ReservationStatus = statusReservString, reservations });
        
                // await context.SaveChangesAsync();
                //return Ok(reservations);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

       
    }
}
