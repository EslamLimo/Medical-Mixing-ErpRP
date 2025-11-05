using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditTrailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AuditTrailsController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditTrail>>> GetAuditTrails()
        {
            return await _context.AuditTrails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuditTrail>> GetAuditTrail(int id)
        {
            var log = await _context.AuditTrails.FindAsync(id);
            if (log == null)
                return NotFound();

            return log;
        }

        [HttpPost]
        public async Task<ActionResult<AuditTrail>> PostAuditTrail(AuditTrail log)
        {
            log.ActionDate = DateTime.Now;
            _context.AuditTrails.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuditTrail), new { id = log.Id }, log);
        }
    }
}
