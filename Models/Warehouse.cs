using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        // كل مخزن به أصناف خام ومنتجات نهائية
        public ICollection<RawItem> RawItems { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
