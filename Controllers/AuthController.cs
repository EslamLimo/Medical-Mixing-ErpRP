using MedicalMixingERP.Api.Data;
using MedicalMixingERP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MedicalMixingERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AuthController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequestDTO req)
        {
            // جلب المستخدم مع التحقق
            var user = _db.Users.FirstOrDefault(u =>
                u.UserName.ToLower() == req.UserName.ToLower()
                && u.PasswordHash == req.Password
                && u.CompanyId == req.CompanyId // <-- قد يكون اسم الجدول ClientID/CompanyID, تأكد من الاسم
            );

            if (user == null)
                return Unauthorized("بيانات الدخول غير صحيحة!");

            var company = _db.Clients.FirstOrDefault(c => c.Id == req.CompanyId);
            if (company == null)
                return BadRequest("الشركة المختارة غير موجودة.");

            // إحضار الصلاحيات
            var roles = (from ur in _db.UserRoles
                         join r in _db.Roles on ur.RoleId equals r.Id
                         where ur.UserId == user.Id
                         select r.RoleName).ToList();

            var response = new LoginResponseDTO
            {
                UserId = user.Id,
                UserName = user.UserName,
                CompanyId = company.Id,
                CompanyName = company.Name,
                CompanyLogo = company.LogoUrl,
                MainColor = company.MainColor,
                SecondaryColor = company.SecondaryColor,
                Lang = company.Language,
                Roles = roles
            };

            return Ok(response);
        }
    }
}
