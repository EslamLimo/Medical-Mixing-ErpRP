using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // علاقة مباشرة بالعميل (الشركة المالكة)
        public int ClientId { get; set; }
        public Client Client { get; set; }

        // علاقة بفروع/مخازن تنتمي لهذا الفرع
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
