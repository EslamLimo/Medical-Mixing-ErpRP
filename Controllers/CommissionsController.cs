using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CommissionsController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commission>>> GetCommissions()
        {
            return await _context.Commissions
                .Include(c => c.SalesRep)
                .Include(c => c.Product)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Commission>> GetCommission(int id)
        {
            var commission = await _context.Commissions
                .Include(c => c.SalesRep)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (commission == null)
                return NotFound();

            return commission;
        }

        [HttpPost]
        public async Task<ActionResult<Commission>> PostCommission(Commission commission)
        {
            commission.CommissionDate = DateTime.Now;
            _context.Commissions.Add(commission);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCommission), new { id = commission.Id }, commission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommission(int id, Commission commission)
        {
            if (id != commission.Id)
                return BadRequest();

            _context.Entry(commission).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Commissions.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommission(int id)
        {
            var commission = await _context.Commissions.FindAsync(id);
            if (commission == null)
                return NotFound();

            _context.Commissions.Remove(commission);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
