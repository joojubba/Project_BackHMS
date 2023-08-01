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
                .Include(hg => hg.HotelGuest)
                .Include(ra => ra.Rate)
                .Include(r => r.Room)
                .Include(p => p.Payment)
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
                .Include(hg => hg.HotelGuest)
                .Include(ra => ra.Rate)
                .Include(r => r.Room)
                .Include(p => p.Payment)
                .AsNoTracking()
                .FirstOrDefaultAsync(ra => ra.ReservationId == id);

            return reservations == null ? NotFound() : Ok(reservations);
        }

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
              
                reservation.Nights = CalculateNights(reservation.Arrival, reservation.Departure);
                if (reservation.Arrival < DateTime.Today || reservation.Departure < reservation.Arrival)
                {
                    return BadRequest("Invalid Date!");
                }

                string rateCode = reservation.Rate.RateCode;
                int nights = reservation.Nights;

                decimal ratePrice = CalculateReservationAmount(context, rateCode, nights);

                reservation.ReservationAmount = ratePrice;

                await context.Reservations.AddAsync(reservation);
                await context.SaveChangesAsync();
                return Created($"api/reservations/{reservation.ReservationId}", reservation);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("reservations/{id}")]
        public async Task<IActionResult> PutAsync(
        [FromServices] Context context,
        [FromBody] Reservation reservation,
        [FromRoute] int id
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            var re = await context
                .Reservations
                .FirstOrDefaultAsync(x => x.ReservationId == id);
            if (re == null)
                return NotFound("Reservation not found!");



            try
            {
                reservation.Nights = CalculateNights(reservation.Arrival, reservation.Departure);
                if (reservation.Arrival < DateTime.Today || reservation.Departure < reservation.Arrival)
                {
                    return BadRequest("Invalid Date!");
                }
               

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
            var re = await context
                .Reservations
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

        [HttpGet]
        [Route("reservations/calculateReservationAmount")]
        public decimal CalculateReservationAmount(Context context, string rateCode, int nights)
        {
            decimal ratePrice = 0;

            var rate = context
               .Rates
               .FirstOrDefault(r => r.RateCode == rateCode);

            if (rate != null)
            {
                ratePrice = rate.RatePrice;
            }

            switch (rateCode)
            {
                case "BAR":
                    ratePrice = ratePrice * nights;
                    break;
                case "NET":
                    ratePrice = ratePrice * nights;
                    break;
                case "CORP":
                    ratePrice = ratePrice * nights;
                    break;
                case "LONG":
                    ratePrice = ratePrice * nights;
                    break;
                case "MON":
                    ratePrice = ratePrice * nights;
                    break;
                case "GRP":
                    ratePrice = ratePrice * nights;
                    break;
            }
            return ratePrice;
        }

        [HttpGet]
        [Route("reservations/calculateNights")]
        public int CalculateNights(DateTime arrival, DateTime departure)
        {
            return (departure - arrival).Days;
        }
    }
}
