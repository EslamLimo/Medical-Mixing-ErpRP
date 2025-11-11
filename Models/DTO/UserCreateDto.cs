using MedicalMixingERP.Api.Models;

namespace MedicalMixingERP.Api.Models.DTO
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        // أضف صلاحيات/حقول أخرى إذا أردت
    }
}
