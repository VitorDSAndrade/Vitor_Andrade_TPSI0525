using Microsoft.AspNetCore.Mvc;
using sharp_01.Data;
using sharp_01.Models;

namespace sharp_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _db;
        public ProductsController(ApiContext db) => _db = db;

        // GET /api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new
            {
                status = "success",
                data = _db.Products.ToList()
            });
        }

        // POST /api/products
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product.Stock == 0)
            {
                return BadRequest(new
                {
                    status = "error",
                    error = "missing_stock",
                    message = "Stock value is required"
                });
            }

            _db.Products.Add(product);
            _db.SaveChanges();

            return StatusCode(201, new
            {
                status = "success",
                data = new
                {
                    id = product.Id,
                    message = "Product added successfully"
                }
            });
        }
    }
}
