using HotelManagementSystem.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HotelManagementSystem.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        [HttpGet]
        [Route("rates")]
        public async Task<IActionResult> getAllAsync(
        [FromServices] Context context)
        {
            var rates = await context
                .Rates
                .AsNoTracking()
                .ToListAsync();

            return rates == null ? NotFound() : Ok(rates);
        }

        [HttpGet]
        [Route("rates/{id}")]
        public async Task<IActionResult> getByIdAsync(
        [FromServices] Context context,
        [FromRoute] int id
           )
        {
            var rates = await context
                .Rates
                .AsNoTracking()
                .FirstOrDefaultAsync(ra => ra.RateId == id);

            return rates == null ? NotFound() : Ok(rates);
        }

        [HttpPost]
        [Route("rates")]
        public async Task<IActionResult> PostAsync(
        [FromServices] Context context,
        [FromBody] Rate rate
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await context.Rates.AddAsync(rate);
                await context.SaveChangesAsync();
                return Created($"api/rates/{rate.RateId}", rate);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut]
        [Route("rates/{id}")]
        public async Task<IActionResult> PutAsync(
        [FromServices] Context context,
        [FromBody] Rate rate,
        [FromRoute] int id
           )
        {
            if (!ModelState.IsValid) return BadRequest();

            var ra = await context.Rates
                .FirstOrDefaultAsync(x => x.RateId == id);
            if (ra == null)
                return NotFound("Rate not found!");

            try
            {
                ra.RateCode = rate.RateCode;
                ra.RatePrice = rate.RatePrice;
                ra.RateDescription = rate.RateDescription;

                context.Rates.Update(ra);
                await context.SaveChangesAsync();
                return Ok(ra);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete]
        [Route("rates/{id}")]
        public async Task<IActionResult> DeleteAsync(
        [FromServices] Context context,
        [FromRoute] int id
           )
        {
            var ra = await context.Rates
                .FirstOrDefaultAsync(x => x.RateId == id);

            if (ra == null)
                return NotFound("Rate not found!");

            try
            {

                context.Rates.Remove(ra);
                await context.SaveChangesAsync();
                return Ok(ra);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }      
    }
}
