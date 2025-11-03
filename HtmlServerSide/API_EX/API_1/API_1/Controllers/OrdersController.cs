using Microsoft.AspNetCore.Mvc;
using sharp_01.Data;
using sharp_01.Models;

namespace sharp_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ApiContext _db;
        public OrdersController(ApiContext db) => _db = db;

        [HttpPost]
        public IActionResult Create(Order order)
        {
            bool exists = _db.Customers.Any(c => c.Id == order.CustomerId);

            if (!exists)
            {
                return NotFound(new
                {
                    status = "error",
                    error = "customer_not_found",
                    message = "Customer ID not found"
                });
            }

            _db.Orders.Add(order);
            _db.SaveChanges();

            return StatusCode(201, new
            {
                status = "success",
                data = new
                {
                    orderId = order.Id,
                    message = "Order created successfully"
                }
            });
        }
    }
}
