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
                         join t in _context.Transactions.ToList() on k.id equals t.kid into transactionsGroup
                         from tg in transactionsGroup.DefaultIfEmpty()
                         group tg by new { k.id, k.name, Type = tg.type } into g
                         select new
                         {
                             Id = g.Key.id,
                             Name = g.Key.name,
                             Credit = g.Sum(t => t != null && t.type == Models.TransactionType.CREDIT ? t.amount : 0),
                             Debit = g.Sum(t => t != null && t.type == Models.TransactionType.DEBIT ? t.amount : 0)
                         };
            return Ok(result);
		}


        [HttpGet("{id}")]
        public async Task<IActionResult> GET(int id)
        {
            var result = from k in _context.Khata.ToList()
                         where k.id == id && k.isDeleted == false
                         join t in _context.Transactions.ToList()
                         on k.id equals t.kid into transactionsGroup
                         from tg in transactionsGroup.DefaultIfEmpty()
                         group tg by new { k.id, k.name, Type = tg.type } into g
                         select new
                         {
                             Id = g.Key.id,
                             Name = g.Key.name,
                             Credit = g.Sum(t => t != null && t.type == Models.TransactionType.CREDIT ? t.amount : 0),
                             Debit = g.Sum(t => t != null && t.type == Models.TransactionType.DEBIT ? t.amount : 0)
                         };
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Khata model)
        {
            _context.Khata.Add(model);
            _context.SaveChanges();
            return Ok();
        }



        [HttpPut]
        public async Task<IActionResult> Update(Khata model)
        {
            var res=_context.Khata.Find(model);
            res.name = model.name;
            res.updatedon = DateTime.UtcNow;
            _context.Khata.Update(res);
            _context.SaveChanges();
            return Ok();
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

