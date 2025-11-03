using Microsoft.AspNetCore.Mvc;
using sharp_01.Data;
using sharp_01.Models;

namespace sharp_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ApiContext _db;
        public LoansController(ApiContext db) => _db = db;

        [HttpPost]
        public IActionResult Create(Loan loan)
        {
            // Imposter logic: bookId = 2 → unavailable
            if (loan.BookId == 2)
            {
                return BadRequest(new
                {
                    status = "error",
                    error = "book_unavailable",
                    message = "This book is already borrowed"
                });
            }

            _db.Loans.Add(loan);
            _db.SaveChanges();

            return StatusCode(201, new
            {
                status = "success",
                data = new
                {
                    loanId = loan.Id,
                    message = "Loan registered successfully"
                }
            });
        }
    }
}
