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

            //var result = from k in _context.Khata.ToList()
            //             where k.isDeleted == false && k.isActive == true && k.userid == _user.id
            //             select k;
            var result = (from k in _context.Khata
                          join t in _context.Transactions on k.id equals t.kid into transactionGroup
                          from t in transactionGroup.DefaultIfEmpty() // Left Join Effect
                          where k.userid == _user.id && k.isActive && !k.isDeleted
                          group t by new
                          {
                              k.id,
                              k.name,
                              k.email,
                              k.contactnumber,
                              k.cretedon,
                              k.updatedon,
                              k.isActive,
                              k.isDeleted,
                              k.userid
                          } into g
                          select new
                          {
                              g.Key.id,
                              g.Key.name,
                              g.Key.email,
                              g.Key.contactnumber,
                              g.Key.cretedon,
                              g.Key.updatedon,
                              g.Key.isActive,
                              g.Key.isDeleted,
                              g.Key.userid,
                              Credit = g.Where(x => x != null && x.isActive && !x.isDeleted && x.type == TransactionType.CREDIT)
                                        .Sum(x => (double?)x.amount) ?? 0,
                              Debit = g.Where(x => x != null && x.isActive && !x.isDeleted && x.type == TransactionType.DEBIT)
                                        .Sum(x => (double?)x.amount) ?? 0
                          }).ToList();


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


        [HttpDelete("{id}")]
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

