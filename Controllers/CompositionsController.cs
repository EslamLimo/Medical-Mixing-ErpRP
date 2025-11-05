using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompositionsController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Composition>>> GetCompositions()
        {
            return await _context.Compositions
                .Include(c => c.CompositionRawItems)
                .Include(c => c.Products)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Composition>> GetComposition(int id)
        {
            var composition = await _context.Compositions
                .Include(c => c.CompositionRawItems)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (composition == null)
                return NotFound();

            return composition;
        }

        [HttpPost]
        public async Task<ActionResult<Composition>> PostComposition(Composition composition)
        {
            composition.CreatedAt = DateTime.Now;
            _context.Compositions.Add(composition);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComposition), new { id = composition.Id }, composition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComposition(int id, Composition composition)
        {
            if (id != composition.Id)
                return BadRequest();

            _context.Entry(composition).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Compositions.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComposition(int id)
        {
            var composition = await _context.Compositions.FindAsync(id);
            if (composition == null)
                return NotFound();

            _context.Compositions.Remove(composition);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
