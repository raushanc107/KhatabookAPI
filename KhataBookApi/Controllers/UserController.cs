using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhataBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        public UserController(ApplicationDbContext _context) : base(_context)
        {
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<List<Users>> List()
        {
            return await _context.Users.Where(e => e.isDeleted == false).ToListAsync();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{userid}")]
        public async Task<Users> List(int userid)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.isDeleted == false && e.id==userid);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("deactivate")]
        public async Task<IActionResult> DeactivateUser(int userid)
        {
            var user = await _context.Users.FindAsync(userid);
            if (user == null)
            {
                return BadRequest("user does not exist");
            }
            user.isActive = false;
            await _context.SaveChangesAsync();
            return Ok(user);
        }


    }
}
