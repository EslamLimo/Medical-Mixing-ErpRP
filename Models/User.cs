using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public int CompanyId { get; set; }
        //public Client Company { get; set; }

        //// صلاحيات المستخدم
        //public ICollection<UserRole> UserRoles { get; set; }

        //// تتبع العمليات والمنشآت
        //public ICollection<UserLog> UserLogs { get; set; }



        public virtual Client Company { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserLog> UserLogs { get; set; }

    }
}
