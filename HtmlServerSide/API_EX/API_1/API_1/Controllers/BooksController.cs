using Microsoft.AspNetCore.Mvc;
using sharp_01.Data;

namespace sharp_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApiContext _db;
        public BooksController(ApiContext db) => _db = db;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = _db.Books.ToList()
            });
        }
    }
}
