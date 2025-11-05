using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class SalesRep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // العمولات المرتبطة بالمندوب
        public ICollection<Commission> Commissions { get; set; }
    }
}
