using System;
using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhataBookApi.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class KhataController:ControllerBase
	{

        private readonly ApplicationDbContext _context;


        public KhataController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var result = from k in _context.Khata.ToList()
                         where k.isDeleted == false && k.isActive == true
                         select k;
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GET(int id)
        {
            var result = from k in _context.Khata.ToList()
                         where k.isDeleted == false && k.isActive == true && k.id==id
                         select k;
            return Ok(result.FirstOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Khata model)
        {
            _context.Khata.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }



        [HttpPut]
        public async Task<IActionResult> Update(Khata model)
        {
            model.updatedon = DateTime.UtcNow;
            _context.Khata.Update(model);
            _context.SaveChanges();
            return Ok(model);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var res = _context.Khata.Find(id);
            res.isDeleted = true;
            res.updatedon = DateTime.UtcNow;
            _context.Khata.Update(res);
            _context.SaveChanges();
            return Ok();
        }




    }
}

