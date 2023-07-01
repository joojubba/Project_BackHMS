using HotelManagementSystem.DataModels;
using HotelManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager;
        public LoginController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this._jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [HttpGet("login")]    
        public string loginEndPoint()
        {
            return "Authorized";
        }  

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public IActionResult Authenticate([FromBody] User user)

        {
            var token = _jWTAuthenticationManager.Authenticate(user.Username, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);

        }
    }
}

