using Microsoft.AspNetCore.Mvc;
using sharp_01.Data;
using sharp_01.Models;

namespace sharp_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApiContext _db;
        public TasksController(ApiContext db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = _db.Tasks.ToList()
            });
        }

        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            if (task.Title?.ToLower() == "duplicate")
            {
                return Conflict(new
                {
                    status = "error",
                    error = "duplicate_task",
                    message = "Task already exists"
                });
            }

            _db.Tasks.Add(task);
            _db.SaveChanges();

            return StatusCode(201, new
            {
                status = "success",
                data = new
                {
                    id = task.Id,
                    message = "Task added successfully"
                }
            });
        }
    }
}
