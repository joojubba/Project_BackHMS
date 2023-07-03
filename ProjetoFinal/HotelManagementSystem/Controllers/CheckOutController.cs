﻿using HotelManagementSystem.DataModels;
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
        //aqui  vejo qm ta out

       

        [HttpGet]
        [Route("checkouts")]
        public async Task<IActionResult> getAllAsync([FromServices] Context context)
        {
            var reservations = await context
                .Reservations
                .Include(r => r.Room)
                .Where(r => r.ReservationStatus == ReservationStatus.CheckedOut)
                .ToListAsync();

            return reservations == null ? NotFound() : Ok(reservations);
        }
       
        //aq consigo dar o out com o num da uh
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
                return NotFound("No hotelguest checked in to this room!");
            
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

            // p converter o valor do enum em uma string
            var statusRoomString = statusRoom.ToString();
            var statusReservString = statusReserv.ToString();

            // retorno a string como parte da resposta

            await context.SaveChangesAsync();
            return Ok(new { Room = rooms, Status = statusRoomString, ReservationStatus = statusReservString, reservations });
        }
    }
}

