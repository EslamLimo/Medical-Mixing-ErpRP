using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        // ارتباط المستخدمين بالدور
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
