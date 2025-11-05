using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionRawItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompositionRawItemsController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositionRawItem>>> GetCompositionRawItems()
        {
            return await _context.CompositionRawItems
                .Include(c => c.RawItem)
                .Include(c => c.Composition)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompositionRawItem>> GetCompositionRawItem(int id)
        {
            var cri = await _context.CompositionRawItems
                .Include(c => c.RawItem)
                .Include(c => c.Composition)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cri == null)
                return NotFound();

            return cri;
        }

        [HttpPost]
        public async Task<ActionResult<CompositionRawItem>> PostCompositionRawItem(CompositionRawItem cri)
        {
            _context.CompositionRawItems.Add(cri);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompositionRawItem), new { id = cri.Id }, cri);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompositionRawItem(int id, CompositionRawItem cri)
        {
            if (id != cri.Id)
                return BadRequest();
            _context.Entry(cri).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CompositionRawItems.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompositionRawItem(int id)
        {
            var cri = await _context.CompositionRawItems.FindAsync(id);
            if (cri == null)
                return NotFound();

            _context.CompositionRawItems.Remove(cri);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
