using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingTransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ShippingTransactionsController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingTransaction>>> GetShippingTransactions()
        {
            return await _context.ShippingTransactions
                .Include(t => t.ShippingCompany)
                .Include(t => t.Product)
                .Include(t => t.SupplierCustomer)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingTransaction>> GetShippingTransaction(int id)
        {
            var trans = await _context.ShippingTransactions
                .Include(t => t.ShippingCompany)
                .Include(t => t.Product)
                .Include(t => t.SupplierCustomer)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trans == null)
                return NotFound();

            return trans;
        }

        [HttpPost]
        public async Task<ActionResult<ShippingTransaction>> PostShippingTransaction(ShippingTransaction trans)
        {
            trans.ShippingDate = DateTime.Now;
            _context.ShippingTransactions.Add(trans);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShippingTransaction), new { id = trans.Id }, trans);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingTransaction(int id, ShippingTransaction trans)
        {
            if (id != trans.Id)
                return BadRequest();

            _context.Entry(trans).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ShippingTransactions.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingTransaction(int id)
        {
            var trans = await _context.ShippingTransactions.FindAsync(id);
            if (trans == null)
                return NotFound();

            _context.ShippingTransactions.Remove(trans);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
