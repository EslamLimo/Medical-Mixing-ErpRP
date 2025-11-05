using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompaniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ShippingCompaniesController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingCompany>>> GetShippingCompanies()
        {
            return await _context.ShippingCompanies.Include(s => s.ShippingTransactions).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingCompany>> GetShippingCompany(int id)
        {
            var company = await _context.ShippingCompanies
                .Include(s => s.ShippingTransactions)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (company == null)
                return NotFound();

            return company;
        }

        [HttpPost]
        public async Task<ActionResult<ShippingCompany>> PostShippingCompany(ShippingCompany company)
        {
            company.CreatedAt = DateTime.Now;
            _context.ShippingCompanies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShippingCompany), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShippingCompany(int id, ShippingCompany company)
        {
            if (id != company.Id)
                return BadRequest();

            _context.Entry(company).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ShippingCompanies.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingCompany(int id)
        {
            var company = await _context.ShippingCompanies.FindAsync(id);
            if (company == null)
                return NotFound();

            _context.ShippingCompanies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
