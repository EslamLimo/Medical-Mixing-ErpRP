using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierCustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SupplierCustomersController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierCustomer>>> GetSupplierCustomers()
        {
            return await _context.SupplierCustomers.Include(s => s.AccountTransactions).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierCustomer>> GetSupplierCustomer(int id)
        {
            var item = await _context.SupplierCustomers.Include(s => s.AccountTransactions)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<SupplierCustomer>> PostSupplierCustomer(SupplierCustomer item)
        {
            item.CreatedAt = DateTime.Now;
            _context.SupplierCustomers.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSupplierCustomer), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplierCustomer(int id, SupplierCustomer item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SupplierCustomers.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplierCustomer(int id)
        {
            var item = await _context.SupplierCustomers.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.SupplierCustomers.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
