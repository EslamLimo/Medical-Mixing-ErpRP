using MedicalMixingERP.Api.Models;
namespace MedicalMixingERP.Api.Models.DTO
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        // لا تضف علاقات Company أو UserRoles أو أي كائنات افتراضية هنا!
    }
}
