using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string MainColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Language { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // تعديل: إزالة أي Required أو تقييد واجعلها مجموعة فارغة من البداية:
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    }
}
