using HotelManagementSystem.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class HotelGuestsController : ControllerBase
    {
   
        [HttpGet]
        [Route("hotelGuests")]
        public async Task<IActionResult> getAllAsync(
       [FromServices] Context context)
        {
            var hotelGuests = await context
                .HotelGuests
                .AsNoTracking()
                .ToListAsync();

            return hotelGuests == null ? NotFound() : Ok(hotelGuests);
        }
    
        [HttpGet]
        [Route("hotelGuests/{id}")]
        public async Task<IActionResult> getByIdAsync(
        [FromServices] Context context,
        [FromRoute] int id
            )
        {
            var hotelGuests = await context
                .HotelGuests
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.HotelGuestId == id);

            return hotelGuests == null ? NotFound() : Ok(hotelGuests);
        }

        [HttpPost]
        [Route("hotelGuests")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromBody] HotelGuest hotelGuest
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await context.HotelGuests.AddAsync(hotelGuest);
                await context.SaveChangesAsync();
                return Created($"api/hotelGuests/{hotelGuest.HotelGuestId}", hotelGuest);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        [Route("hotelGuests/{id}")]
        public async Task<IActionResult> PutAsync(
        [FromServices] Context context,
        [FromBody] HotelGuest hotelGuest,
        [FromRoute] int id
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            var hotelGuests = await context.HotelGuests
                .FirstOrDefaultAsync(x => x.HotelGuestId == id);
            if (hotelGuests == null)
                return NotFound("HotelGuest not found!");

            try
            {
                hotelGuests.HotelGuestName = hotelGuest.HotelGuestName;
                hotelGuests.HotelGuestIdentification = hotelGuest.HotelGuestIdentification;
                hotelGuests.HotelGuestEmail = hotelGuest.HotelGuestEmail;
                hotelGuests.HotelGuestPhone = hotelGuest.HotelGuestPhone;
                hotelGuests.HotelGuestAddress = hotelGuest.HotelGuestAddress;
                hotelGuests.DateBirthHotelGuest = hotelGuest.DateBirthHotelGuest;

                context.HotelGuests.Update(hotelGuests);
                await context.SaveChangesAsync();
                return Ok(hotelGuests);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete]
        [Route("hotelGuests/{id}")]
        public async Task<IActionResult> DeleteAsync(
        [FromServices] Context context,
        [FromRoute] int id
           )
        {
            var hotelGuests = await context.HotelGuests
                .FirstOrDefaultAsync(x => x.HotelGuestId == id);

            if (hotelGuests == null)
                return NotFound("HotelGuest not found!");

            try
            {

                context.HotelGuests.Remove(hotelGuests);
                await context.SaveChangesAsync();
                return Ok(hotelGuests);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

    }
}
