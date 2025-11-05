using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryTransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoryTransactionsController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryTransaction>>> GetInventoryTransactions()
        {
            return await _context.InventoryTransactions
                .Include(i => i.Warehouse)
                .Include(i => i.RawItem)
                .Include(i => i.Product)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryTransaction>> GetInventoryTransaction(int id)
        {
            var inv = await _context.InventoryTransactions
                .Include(i => i.Warehouse)
                .Include(i => i.RawItem)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inv == null)
                return NotFound();

            return inv;
        }

        [HttpPost]
        public async Task<ActionResult<InventoryTransaction>> PostInventoryTransaction(InventoryTransaction inv)
        {
            inv.TransactionDate = DateTime.Now;
            _context.InventoryTransactions.Add(inv);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInventoryTransaction), new { id = inv.Id }, inv);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryTransaction(int id, InventoryTransaction inv)
        {
            if (id != inv.Id)
                return BadRequest();

            _context.Entry(inv).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.InventoryTransactions.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryTransaction(int id)
        {
            var inv = await _context.InventoryTransactions.FindAsync(id);
            if (inv == null)
                return NotFound();

            _context.InventoryTransactions.Remove(inv);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
