using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShokanApi.Dtos.LoanDto;
using ShokanApi.Dtos.UserDto;
using ShokanApi.Models;
using ShokanApi.Utils;

namespace ShokanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ShokanContext _context;

        public LoansController(ShokanContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateLoan(CreateLoanRequest dto)
        {
            var loan = new Loan
            {
                BookId = dto.IdBook,
                UserId = dto.IdUser,
                LoanDate = DateTime.UtcNow
            };
            _context.Loans.Add(loan);
            var book = await _context.Books.FindAsync(dto.IdBook);
            if (book == null)
            {
                return NotFound();
            }

            book.Borrowed = true;
            book.LenderId = dto.IdUser;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
