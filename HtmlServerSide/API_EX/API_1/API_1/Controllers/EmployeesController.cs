using Microsoft.AspNetCore.Mvc;
using sharp_01.Data;
using sharp_01.Models;

namespace sharp_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ApiContext _db;
        public EmployeesController(ApiContext db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = _db.Employees.ToList()
            });
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (e.Salary <= 0)
            {
                return BadRequest(new
                {
                    status = "error",
                    error = "invalid_salary",
                    message = "Salary must be greater than zero"
                });
            }

            _db.Employees.Add(e);
            _db.SaveChanges();

            return StatusCode(201, new
            {
                status = "success",
                data = new
                {
                    id = e.Id,
                    message = "Employee created"
                }
            });
        }
    }
}
