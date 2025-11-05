using System;

namespace MedicalMixingERP.Api.Models
{
    public class UserLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
        public string Details { get; set; }
    }
}
