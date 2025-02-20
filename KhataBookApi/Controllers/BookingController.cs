using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhataBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : BaseController
    {
        public BookingController(ApplicationDbContext _context) : base(_context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            if (User.IsInRole("Admin"))
            {
                var res = from b in _context.Booking
                          join c in _context.Cars on b.carid equals c.id
                          join ct in _context.City on b.cityid equals ct.id
                          select new
                          {
                              id = b.id,
                              userid = b.userid,
                              car = c,
                              city = ct,
                              subscriptiontenure = b.subscriptiontenure,
                              monthlyFees = b.monthlyFees,
                              taxPercentage = b.monthlyFees,
                              taxAmount = b.taxAmount,
                              bookingCharge = b.bookingCharge,
                              processingFees = b.processingFees,
                              depositAmount = b.depositAmount,
                              totalPayableAmount = b.totalPayableAmount,
                              cretedon = b.cretedon,
                              isActive = b.isActive,
                              updatedon = b.updatedon,
                          };
                return Ok(res);
            }
            var res2 = from b in _context.Booking
                      join c in _context.Cars on b.carid equals c.id
                      join ct in _context.City on b.cityid equals ct.id
                      where b.userid == _user.id
                      select new
                      {
                          id = b.id,
                          userid = b.userid,
                          car = c,
                          city = ct,
                          subscriptiontenure = b.subscriptiontenure,
                          monthlyFees = b.monthlyFees,
                          taxPercentage = b.monthlyFees,
                          taxAmount = b.taxAmount,
                          bookingCharge = b.bookingCharge,
                          processingFees = b.processingFees,
                          depositAmount = b.depositAmount,
                          totalPayableAmount = b.totalPayableAmount,
                          cretedon=b.cretedon,
                          isActive=b.isActive,
                          updatedon=b.updatedon,
                      };
            return Ok(res2);
        }


        [HttpGet("{bookingId}")]
        public async Task<IActionResult> Get(int bookingId)
        {
            if (User.IsInRole("Admin"))
            {
                var res = from b in _context.Booking
                           join c in _context.Cars on b.carid equals c.id
                           join ct in _context.City on b.cityid equals ct.id
                           where b.id == bookingId
                           select new
                           {
                               id = b.id,
                               userid = b.userid,
                               car = c,
                               city = ct,
                               subscriptiontenure = b.subscriptiontenure,
                               monthlyFees = b.monthlyFees,
                               taxPercentage = b.monthlyFees,
                               taxAmount = b.taxAmount,
                               bookingCharge = b.bookingCharge,
                               processingFees = b.processingFees,
                               depositAmount = b.depositAmount,
                               totalPayableAmount = b.totalPayableAmount,
                               cretedon = b.cretedon,
                               isActive = b.isActive,
                               updatedon = b.updatedon,
                           };
                return Ok(res.FirstOrDefault());
            }
            var res2 = from b in _context.Booking
                      join c in _context.Cars on b.carid equals c.id
                      join ct in _context.City on b.cityid equals ct.id
                      where b.id == bookingId && b.userid == _user.id
                      select new
                      {
                          id = b.id,
                          userid = b.userid,
                          car = c,
                          city = ct,
                          subscriptiontenure = b.subscriptiontenure,
                          monthlyFees = b.monthlyFees,
                          taxPercentage = b.monthlyFees,
                          taxAmount = b.taxAmount,
                          bookingCharge = b.bookingCharge,
                          processingFees = b.processingFees,
                          depositAmount = b.depositAmount,
                          totalPayableAmount = b.totalPayableAmount,
                          cretedon = b.cretedon,
                          isActive = b.isActive,
                          updatedon = b.updatedon,
                      };
            return Ok(res2.FirstOrDefault());
        }

        [HttpGet("ByEmail{useremail}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetByUser(string useremail)
        {
            var res = from b in _context.Booking
                      join c in _context.Cars on b.carid equals c.id
                      join ct in _context.City on b.cityid equals ct.id
                      join u in _context.Users on b.userid equals u.id
                      where  u.email== useremail
                      select new
                      {
                          id = b.id,
                          userid = b.userid,
                          car = c,
                          city = ct,
                          subscriptiontenure = b.subscriptiontenure,
                          monthlyFees = b.monthlyFees,
                          taxPercentage = b.monthlyFees,
                          taxAmount = b.taxAmount,
                          bookingCharge = b.bookingCharge,
                          processingFees = b.processingFees,
                          depositAmount = b.depositAmount,
                          totalPayableAmount = b.totalPayableAmount,
                          cretedon = b.cretedon,
                          isActive = b.isActive,
                          updatedon = b.updatedon,
                      };
            return Ok(res);


        }

        [HttpPost]
        public async Task<IActionResult> book(Booking booking)
        {
            booking.userid=_user.id;
            _context.Booking.Add(booking);
            _context.SaveChanges();
            var res=from b in _context.Booking
            join c in _context.Cars on b.carid equals c.id
            join ct in _context.City on b.cityid equals ct.id
            where b.id==booking.id && b.userid==_user.id
            select new
            {
                id = b.id,
                userid = b.userid,
                car = c,
                city = ct,
                subscriptiontenure = b.subscriptiontenure,
                monthlyFees = b.monthlyFees,
                taxPercentage = b.monthlyFees,
                taxAmount = b.taxAmount,
                bookingCharge = b.bookingCharge,
                processingFees = b.processingFees,
                depositAmount = b.depositAmount,
                totalPayableAmount = b.totalPayableAmount,
                cretedon = b.cretedon,
                isActive = b.isActive,
                updatedon = b.updatedon,
            };
            return Ok(res.FirstOrDefault());
        }
        

    }
}
