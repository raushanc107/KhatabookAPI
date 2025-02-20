using KhataBookApi.Data;
using KhataBookApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhataBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CarController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = from c in _context.Cars
                         join rd in _context.RentDetails on c.id equals rd.carid
                         join ct in _context.City on rd.cityId equals ct.id
                         where !c.isDeleted && c.isActive && !ct.isDeleted && ct.isActive && rd.isActive && !rd.isDeleted
                         select new
                         {
                            carId=c.id,
                            carName=c.carName,
                            carImage=c.imageURL,
                            carBrand=c.brand,
                            carFuelType=c.fuelType,
                            carTransmissionType=c.TransmissionType,
                            carIsHybrid=c.isHybrid,
                            carIsNew=c.isNew,
                            carSegment=c.Segments,
                            cityId=ct.id,
                            cityName=ct.cityname,
                            carRentalId=rd.id,
                            carAmount=rd.amount,
                            carTax=rd.tax,
                            carDiscount=rd.discount,
                            carAvailableIn=rd.availablein
                         };

            return Ok(result);
        }

        [HttpGet("{cityid}")]
        public async Task<IActionResult> List(int cityid)
        {
            var result = from c in _context.Cars
                         join rd in _context.RentDetails on c.id equals rd.carid
                         join ct in _context.City on rd.cityId equals ct.id
                         where !c.isDeleted && c.isActive && !ct.isDeleted && ct.isActive && rd.isActive && !rd.isDeleted && ct.id==cityid
                         select new
                         {
                             carId = c.id,
                             carName = c.carName,
                             carImage = c.imageURL,
                             carBrand = c.brand,
                             carFuelType = c.fuelType,
                             carTransmissionType = c.TransmissionType,
                             carIsHybrid = c.isHybrid,
                             carIsNew = c.isNew,
                             carSegment = c.Segments,
                             cityId = ct.id,
                             cityName = ct.cityname,
                             carRentalId = rd.id,
                             carAmount = rd.amount,
                             carTax = rd.tax,
                             carDiscount = rd.discount,
                             carAvailableIn = rd.availablein
                         };

            return Ok(result);
        }


        [HttpGet("{carid}/{cityid}")]
        public async Task<IActionResult> Get(int carid,int cityid)
        {
            var result = (from c in _context.Cars
                         join rd in _context.RentDetails on c.id equals rd.carid
                         join ct in _context.City on rd.cityId equals ct.id
                         where !c.isDeleted && c.isActive && !ct.isDeleted && ct.isActive && rd.isActive && !rd.isDeleted && c.id== carid && ct.id==cityid
                         select new
                         {
                             carId = c.id,
                             carName = c.carName,
                             carImage = c.imageURL,
                             carBrand = c.brand,
                             carFuelType = c.fuelType,
                             carTransmissionType = c.TransmissionType,
                             carIsHybrid = c.isHybrid,
                             carIsNew = c.isNew,
                             carSegment = c.Segments,
                             cityId = ct.id,
                             cityName = ct.cityname,
                             carRentalId = rd.id,
                             carAmount = rd.amount,
                             carTax = rd.tax,
                             carDiscount = rd.discount,
                             carAvailableIn = rd.availablein
                         }).FirstOrDefault();
            return Ok(result);
        }



        [Authorize("Admin")]
        [HttpPost]
        public async Task<Cars> Add(Cars model)
        {
            _context.Cars.Add(model);
            _context.SaveChanges();
            return model;

        }

        [Authorize("Admin")]
        [HttpPut]
        public async Task<Cars> Update(Cars model)
        {
            model.updatedon = DateTime.UtcNow;
            _context.Cars.Update(model);
            _context.SaveChanges();
            return model;
        }


        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Cars.FindAsync(id);
            model.updatedon = DateTime.UtcNow;
            model.isDeleted = true;
            _context.Cars.Update(model);
            _context.SaveChanges();
            return Ok();
        }
    }
}
