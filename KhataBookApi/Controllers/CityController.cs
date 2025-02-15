using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhataBookApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<List<City>> ListCity() {
            return await _context.City.Where(e=>e.isActive==true&&e.isDeleted==false).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<City> GetCity(int id)
        {
            return await _context.City.FirstOrDefaultAsync(e => e.id == id && e.isActive == true && e.isDeleted == false);
        }


        [Authorize("Admin")]
        [HttpPost]
        public async Task<City> Add(City model)
        {
            _context.City.Add(model);
            _context.SaveChanges();
            return model;

        }

        [Authorize("Admin")]
        [HttpPut]
        public async Task<City> Update(City model)
        {
            model.updatedon = DateTime.UtcNow;
            _context.City.Update(model);
            _context.SaveChanges();
            return model;
        }


        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.City.FindAsync(id);
            model.updatedon = DateTime.UtcNow;
            model.isDeleted = true;
            _context.City.Update(model);
            _context.SaveChanges();
            return Ok();
        }





    }
}
