using HotelManagementSystem.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        [HttpGet]
        [Route("payments")]
        public async Task<IActionResult> getAllAsync(
        [FromServices] Context context)
        {
            var payments = await context
                .Payments              
                .AsNoTracking()
                .ToListAsync();

            return payments == null ? NotFound() : Ok(payments);
        }

 

        [HttpPost]
        [Route("{reservationId}/payments")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromBody] Payment payment,
        [FromRoute] int reservationId

        )
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var reservation = await context
                    .Reservations
                    .FindAsync(reservationId);

                if (reservation == null)
                {
                    return NotFound("Reservation not found!");
                }

                reservation.Payment = payment;

                await context.Payments.AddAsync(payment);
                await context.SaveChangesAsync();
                return Created($"api/payments/{payment.PaymentId}", payment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return BadRequest(ex.Message);
            }

        }

    }
}
