using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
        {
            return await _context.Expenses.Include(e => e.Product).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var exp = await _context.Expenses.Include(e => e.Product)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exp == null)
                return NotFound();

            return exp;
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense exp)
        {
            exp.ExpenseDate = DateTime.Now;
            _context.Expenses.Add(exp);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpense), new { id = exp.Id }, exp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, Expense exp)
        {
            if (id != exp.Id)
                return BadRequest();

            _context.Entry(exp).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Expenses.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var exp = await _context.Expenses.FindAsync(id);
            if (exp == null)
                return NotFound();

            _context.Expenses.Remove(exp);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
