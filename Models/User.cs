using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // صلاحيات المستخدم
        public ICollection<UserRole> UserRoles { get; set; }

        // تتبع العمليات والمنشآت
        public ICollection<UserLog> UserLogs { get; set; }
    }
}
