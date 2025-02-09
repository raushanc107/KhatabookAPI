using System.Security.Cryptography;
using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhataBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : BaseController
    {
        
        public TransactionController(ApplicationDbContext context):base(context)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = from e in _context.Transactions.ToList()
                         where e.isDeleted == false && e.isActive == true
                         select e;
            return Ok(result);
        }

        [HttpGet("{kid}")]
        public IActionResult Get(int kid) { 
            var result=from e in _context.Transactions.ToList()
                       where e.isDeleted == false && e.isActive==true && e.kid==kid
                       select e;
            return Ok(result);
            
        }

        [HttpGet("{kid}/{id}")]
        public IActionResult Get(int kid,int id) {
            var result = from e in _context.Transactions.ToList()
                         where e.isDeleted == false && e.isActive == true && e.id == id && e.kid == kid
                         select e;
            return Ok(result.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Post(Transactions model)
        {
            _context.Transactions.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put(Transactions model) {
            model.updatedon = DateTime.UtcNow;
            _context.Update(model);
            _context.SaveChanges();
            return Ok(model);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            var model=_context.Transactions.ToList().Find(e => e.id==id);
            model.isDeleted = true;
            model.updatedon = DateTime.UtcNow;
            _context.Update(model);
            _context.SaveChanges();
            return Ok();
        }


    }
}
