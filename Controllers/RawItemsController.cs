using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RawItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RawItem>>> GetRawItems()
        {
            return await _context.RawItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RawItem>> GetRawItem(int id)
        {
            var rawItem = await _context.RawItems.FindAsync(id);

            if (rawItem == null)
                return NotFound();

            return rawItem;
        }

        [HttpPost]
        public async Task<ActionResult<RawItem>> PostRawItem(RawItem rawItem)
        {
            rawItem.CreatedAt = DateTime.Now;
            _context.RawItems.Add(rawItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRawItem), new { id = rawItem.Id }, rawItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRawItem(int id, RawItem rawItem)
        {
            if (id != rawItem.Id)
                return BadRequest();

            _context.Entry(rawItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RawItems.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRawItem(int id)
        {
            var rawItem = await _context.RawItems.FindAsync(id);
            if (rawItem == null)
                return NotFound();

            _context.RawItems.Remove(rawItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
