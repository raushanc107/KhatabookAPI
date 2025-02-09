using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using KhataBookApi.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KhataBookApi.Models
{
    public class HashingRepo
    {
        public static IConfiguration _configuration;

        static HashingRepo()
        {
            var serviceProvider = GetServiceProvider();
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
        }
        private static IServiceProvider GetServiceProvider()
        {
            var httpContextAccessor = new HttpContextAccessor();
            return httpContextAccessor.HttpContext?.RequestServices;
        }

        public static string HashPassword(string Password)
        {
            try
            {
                using var sha256 = SHA256.Create();
                return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(Password)));
            }
            catch
            {
                throw;
            }
        }

        public static Boolean veriVerifyPassword(string Password, string Hash)
        {
            try
            {
                return HashPassword(Password) == Hash;
            }
            catch { throw; }
        }




        public static string GenerateJwtToken(Users user)
        {
            try
            {
                var claims = new[]
                {
            new Claim(ClaimTypes.Name, user.Firstname+" "+user.Lastname),
            new Claim(ClaimTypes.Email, user.email),
            new Claim(ClaimTypes.Role,user.role)
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch
            {
                throw;
            }
        }
    }
}
