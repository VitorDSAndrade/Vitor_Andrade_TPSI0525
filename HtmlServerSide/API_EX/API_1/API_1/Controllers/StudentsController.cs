using Microsoft.AspNetCore.Mvc;
using sharp_01.Data;
using sharp_01.Models;

namespace sharp_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApiContext _db;
        public StudentsController(ApiContext db) => _db = db;

        // GET /api/students
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = _db.Students.ToList()
            });
        }

        // POST /api/students
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (student.Age == 0)
            {
                return BadRequest(new
                {
                    status = "error",
                    error = "missing_field",
                    message = "Field 'age' is required"
                });
            }

            _db.Students.Add(student);
            _db.SaveChanges();

            return StatusCode(201, new
            {
                status = "success",
                data = new
                {
                    id = student.Id,
                    message = "Student created successfully"
                }
            });
        }
    }
}
