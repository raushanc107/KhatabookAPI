using System;
using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhataBookApi.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class KhataController:BaseController
	{

        public KhataController(ApplicationDbContext _context):base(_context)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var result = from k in _context.Khata.ToList()
                         where k.isDeleted == false && k.isActive == true && k.userid == _user.id
                         select k;
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GET(int id)
        {
            var result = from k in _context.Khata.ToList()
                         where k.isDeleted == false && k.isActive == true && k.id==id && k.userid == _user.id
                         select k;
            return Ok(result.FirstOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Khata model)
        {
            model.userid = _user.id;
            _context.Khata.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }



        [HttpPut]
        public async Task<IActionResult> Update(Khata model)
        {
            model.userid = _user.id;
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

