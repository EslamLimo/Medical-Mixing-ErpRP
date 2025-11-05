using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class Composition
    {
        public int Id { get; set; }
        public string Name { get; set; } // اسم التركيبة
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // الأصناف الخام في التركيبة
        public ICollection<CompositionRawItem> CompositionRawItems { get; set; }
        // المنتجات الناتجة من التركيبة
        public ICollection<Product> Products { get; set; }
    }
}
