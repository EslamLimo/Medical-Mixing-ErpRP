using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using MedicalMixingERP.Api.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserRolesController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRoles()
        {
            return await _context.UserRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUserRole(int id)
        {
            var ur = await _context.UserRoles
                .Include(u => u.User)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(ur => ur.Id == id);

            if (ur == null)
                return NotFound();

            return ur;
        }

        //[HttpPost]
        //public async Task<ActionResult<UserRole>> PostUserRole(UserRole ur)
        //{
        //    _context.UserRoles.Add(ur);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetUserRole), new { id = ur.Id }, ur);
        //}
        [HttpPost]
        public async Task<ActionResult<UserRole>> PostUserRole(UserRoleCreateDto dto)
        {
            var ur = new UserRole
            {
                UserId = dto.UserId,
                RoleId = dto.RoleId
            };

            _context.UserRoles.Add(ur);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserRole), new { id = ur.Id }, ur);
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserRole(int id, UserRole ur)
        //{
        //    if (id != ur.Id)
        //        return BadRequest();

        //    _context.Entry(ur).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_context.UserRoles.Any(e => e.Id == id))
        //            return NotFound();
        //        else
        //            throw;
        //    }
        //    return NoContent();
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(int id, UserRoleUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var ur = await _context.UserRoles.FindAsync(id);
            if (ur == null)
                return NotFound();

            ur.UserId = dto.UserId;
            ur.RoleId = dto.RoleId;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var ur = await _context.UserRoles.FindAsync(id);
            if (ur == null)
                return NotFound();

            _context.UserRoles.Remove(ur);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
