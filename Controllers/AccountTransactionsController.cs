using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountTransactionsController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountTransaction>>> GetAccountTransactions()
        {
            return await _context.AccountTransactions
                .Include(a => a.SupplierCustomer)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountTransaction>> GetAccountTransaction(int id)
        {
            var acc = await _context.AccountTransactions
                .Include(a => a.SupplierCustomer)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (acc == null)
                return NotFound();

            return acc;
        }

        [HttpPost]
        public async Task<ActionResult<AccountTransaction>> PostAccountTransaction(AccountTransaction acc)
        {
            acc.TransactionDate = DateTime.Now;
            _context.AccountTransactions.Add(acc);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccountTransaction), new { id = acc.Id }, acc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountTransaction(int id, AccountTransaction acc)
        {
            if (id != acc.Id)
                return BadRequest();

            _context.Entry(acc).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AccountTransactions.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountTransaction(int id)
        {
            var acc = await _context.AccountTransactions.FindAsync(id);
            if (acc == null)
                return NotFound();

            _context.AccountTransactions.Remove(acc);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
