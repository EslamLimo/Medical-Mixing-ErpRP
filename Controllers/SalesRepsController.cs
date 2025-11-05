using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRepsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SalesRepsController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesRep>>> GetSalesReps()
        {
            return await _context.SalesReps.Include(s => s.Commissions).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesRep>> GetSalesRep(int id)
        {
            var rep = await _context.SalesReps.Include(s => s.Commissions)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (rep == null)
                return NotFound();

            return rep;
        }

        [HttpPost]
        public async Task<ActionResult<SalesRep>> PostSalesRep(SalesRep rep)
        {
            rep.CreatedAt = DateTime.Now;
            _context.SalesReps.Add(rep);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalesRep), new { id = rep.Id }, rep);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesRep(int id, SalesRep rep)
        {
            if (id != rep.Id)
                return BadRequest();

            _context.Entry(rep).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SalesReps.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesRep(int id)
        {
            var rep = await _context.SalesReps.FindAsync(id);
            if (rep == null)
                return NotFound();

            _context.SalesReps.Remove(rep);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
