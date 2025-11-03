using Microsoft.AspNetCore.Mvc;
using sharp_01.Data;
using sharp_01.Models;

namespace sharp_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiContext _db;
        public ReservationsController(ApiContext db) => _db = db;

        // GET /api/reservations
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = _db.Reservations.ToList()
            });
        }

        // POST /api/reservations
        [HttpPost]
        public IActionResult Create(Reservation r)
        {
            if (r.Room == 0)
            {
                return BadRequest(new
                {
                    status = "error",
                    error = "missing_room",
                    message = "Room field is required"
                });
            }

            _db.Reservations.Add(r);
            _db.SaveChanges();

            return StatusCode(201, new
            {
                status = "success",
                data = new
                {
                    id = r.Id,
                    message = "Reservation created"
                }
            });
        }
    }
}
