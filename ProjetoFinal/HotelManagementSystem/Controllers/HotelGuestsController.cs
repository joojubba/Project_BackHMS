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

            var hg = await context.HotelGuests
                .FirstOrDefaultAsync(x => x.HotelGuestId == id);
            if (hg == null)
                return NotFound("HotelGuest not found!");

            try
            {
                hg.HotelGuestName = hotelGuest.HotelGuestName;
                hg.HotelGuestIdentification = hotelGuest.HotelGuestIdentification;
                hg.HotelGuestEmail = hotelGuest.HotelGuestEmail;
                hg.HotelGuestPhone = hotelGuest.HotelGuestPhone;
                hg.HotelGuestAddress = hotelGuest.HotelGuestAddress;
                hg.DateBirthHotelGuest = hotelGuest.DateBirthHotelGuest;

                context.HotelGuests.Update(hg);
                await context.SaveChangesAsync();
                return Ok(hg);
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
            var hg = await context.HotelGuests
                .FirstOrDefaultAsync(x => x.HotelGuestId == id);

            if (hg == null)
                return NotFound("HotelGuest not found!");

            try
            {

                context.HotelGuests.Remove(hg);
                await context.SaveChangesAsync();
                return Ok(hg);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

    }
}
