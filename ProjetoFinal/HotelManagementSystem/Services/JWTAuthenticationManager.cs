using HotelManagementSystem.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelManagementSystem.Services
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string tokenKey;
        private readonly Context context;

        public JWTAuthenticationManager([FromServices] string tokenKey, Context context)
        {
            this.tokenKey = tokenKey;
            this.context = context;
        }

        public string Authenticate(string username, string password)
        {
            var users = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (users == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.TokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, users.Role)
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials
            (
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
      
    }

}
