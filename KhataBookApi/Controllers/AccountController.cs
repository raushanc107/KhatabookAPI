using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhataBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Return validation errors in a structured format
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    return BadRequest(new { Message = "Validation Failed", Errors = errors });
                }

                 

                if (_context.Users.Where(E=>E.email==request.Email).Any())
                {
                    return BadRequest("Username already exists.");
                }

                var user = new Users
                {
                    Firstname = request.firstname,
                    Lastname = request.lastname,
                    email = request.Email,
                    password = HashingRepo.HashPassword(request.Password),
                    
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Return validation errors in a structured format
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    return BadRequest(new { Message = "Validation Failed", Errors = errors });
                }
                var user = _context.Users.Where(E => E.email == request.Email).FirstOrDefault();
                if (user == null || !HashingRepo.veriVerifyPassword(request.Password, user.password))
                {
                    return Unauthorized("Invalid credentials.");
                }
                var token = HashingRepo.GenerateJwtToken(user);
                return Ok(new {FirstName=user.Firstname,LastName=user.Lastname,Role=user.role,email=user.email,Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }




    }
}
