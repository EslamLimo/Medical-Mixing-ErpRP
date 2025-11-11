using MedicalMixingERP.Api.Models;
namespace MedicalMixingERP.Api.Models.DTO
{
    public class UserRoleUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
