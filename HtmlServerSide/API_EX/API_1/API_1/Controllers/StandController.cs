using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using sharp_01.Data;
using sharp_01.Models;

namespace sharp_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandController : ControllerBase
    {
        private readonly ApiContext _context;
        public StandController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("/CreateEdit")]
        public JsonResult CreateEdit(StandCars StandVal)
        {
            if (StandVal.Id == 0)
            {
                _context.StandCar.Add(StandVal);
            }
            else
            {
                var StandValInDb = _context.StandCar.Find(StandVal.Id);
                if (StandValInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                StandValInDb = StandVal;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(StandVal));
        }

        /*[HttpGet("GetCar")]
        public JsonResult GetCar(int CarID)
        {
            var StandValInDb = _context.StandCar.Find(CarID);
            if (StandValInDb == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(StandValInDb));
        }*/

        // Change return type from JsonResult to IActionResult
        [HttpGet("GetCar")]
        public IActionResult GetCar(int CarID) // <--- Changed return type
        {
            var StandValInDb = _context.StandCar.Find(CarID);
            if (StandValInDb == null)
            {
                // Correctly return the NotFound result
                return NotFound();
            }
            // Correctly return the Ok result with the data
            return Ok(StandValInDb);
        }

        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.StandCar.ToList();
            return new JsonResult(Ok(result));
        }

        [HttpDelete("/Delete")]
        public JsonResult Delete(int CarID)
        {
            var StandValInDb = _context.StandCar.Find(CarID);
            if (StandValInDb == null)
            {
                return new JsonResult(NotFound());
            }
            _context.StandCar.Remove(StandValInDb);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }
    }
}