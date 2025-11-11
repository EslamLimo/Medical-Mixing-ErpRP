using Microsoft.AspNetCore.Mvc;
using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Api.Models;
using MedicalMixingERP.Api.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MedicalMixingERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .Include(u => u.UserLogs)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                .Include(u => u.UserLogs)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    user.CreatedAt = DateTime.Now;
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        //}
        public async Task<ActionResult<User>> PostUser(UserCreateDto dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                FullName = dto.FullName,
                PasswordHash = dto.PasswordHash,
                Email = dto.Email,
                Phone = dto.Phone,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now,
                CompanyId = dto.CompanyId
                // لا تربط Company هنا من البيانات المرسلة نهائيًا
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.Id)
        //        return BadRequest();

        //    _context.Entry(user).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_context.Users.Any(e => e.Id == id))
        //            return NotFound();
        //        else
        //            throw;
        //    }
        //    return NoContent();
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            // تحديث الحقول المطلوبة فقط
            user.UserName = dto.UserName;
            user.FullName = dto.FullName;
            user.PasswordHash = dto.PasswordHash;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.IsActive = dto.IsActive;
            user.CompanyId = dto.CompanyId;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
