using HotelManagementSystem.DataModels;
using HotelManagementSystem.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservation = HotelManagementSystem.DataModels.Reservation;

 
namespace HotelManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        [HttpGet]
        [Route("reservations")]
        public async Task<IActionResult> getAllAsync(
        [FromServices] Context context)
        {
            var reservations = await context
                .Reservations
                .AsNoTracking()
                .ToListAsync();

            return reservations == null ? NotFound() : Ok(reservations);
        }

        [HttpGet]
        [Route("reservations/{id}")]
        public async Task<IActionResult> getByIdAsync(
        [FromServices] Context context,
        [FromRoute] int id
           )
        {
            var reservations = await context
                .Reservations
                .Include(ra => ra.Rate) //verificar as trf
                .AsNoTracking()
                .FirstOrDefaultAsync(ra => ra.ReservationId == id);

            return reservations == null ? NotFound() : Ok(reservations);
        }

        //calcular tarifa * noites
        [HttpPost]
        [Route("reservations")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromBody] Reservation reservation
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {

                await context.Reservations.AddAsync(reservation);
                await context.SaveChangesAsync();
                return Created($"api/reservations/{reservation.ReservationId}", reservation);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        /* [HttpPost]
         [Route("reservations")]
         public async Task<IActionResult> PostAsync(
         [FromServices] Context context,
         [FromBody] Reservation reservation
            )
         {
             if (!ModelState.IsValid) return BadRequest();

             try
             {
                 string roomType = reservation.Room.RoomType;
                 string rateCode = reservation.Rate.RateCode;
                 int numberGuests = reservation.NumberGuests;

                 decimal ratePrice = CalculateRateAmount(context, rateCode, roomType, numberGuests);

                 reservation.ReservationAmount = ratePrice;

                 await context.Reservations.AddAsync(reservation);
                 await context.SaveChangesAsync();
                 return Created($"api/reservations/{reservation.ReservationId}", reservation);

             }
             catch (Exception ex) { return BadRequest(ex.Message); }
         }*/

        [HttpPut]
        [Route("reservations/{id}")]
        public async Task<IActionResult> PutAsync(
        [FromServices] Context context,
        [FromBody] Reservation reservation,
        [FromRoute] int id
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            var re = await context.Reservations
                .FirstOrDefaultAsync(x => x.ReservationId == id);
            if (re == null)
                return NotFound("Reservation not found!");

            try
            {
                re.Arrival = reservation.Arrival;
                re.Departure = reservation.Departure;
                re.Source = reservation.Source;
                re.Nights = reservation.Nights;

                context.Reservations.Update(re);
                await context.SaveChangesAsync();
                return Ok(re);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpDelete]
        [Route("reservations/{id}")]
        public async Task<IActionResult> DeleteAsync(
        [FromServices] Context context,
        [FromRoute] int id
           )
        {
            var re = await context.Reservations
                .FirstOrDefaultAsync(x => x.ReservationId == id);

            if (re == null)
                return NotFound("Reservation not found!");

            try
            {

                context.Reservations.Remove(re);
                await context.SaveChangesAsync();
                return Ok(re);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        /*[HttpGet]
        [Route("reservations/calculateRateAmount")]
        public decimal CalculateRateAmount(Context context, string rateCode, string roomType, int numberGuests)
        {
            decimal ratePrice = 0;

            var rate = context.Rates.FirstOrDefault(r => r.RateCode == rateCode);

            if (rate != null)
            {
                ratePrice = rate.RatePrice;
            }

            switch (roomType)
            {
                case "TWN":
                    ratePrice = numberGuests == 2 ? 46 : 0;
                    break;
                case "DBL":
                    ratePrice = numberGuests == 2 ? 67 : 21;
                    break;
                case "DLX":
                    ratePrice = numberGuests == 2 ? 88 : 42;
                    break;
            }

            return ratePrice;
        }*/
        
    }
}
