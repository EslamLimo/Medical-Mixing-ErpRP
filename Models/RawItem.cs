using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class RawItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } // (عناية بالبشره - عناية بالشعر ... الخ)
        public string Code { get; set; }
        public string Unit { get; set; } // وحدة القياس (قطعة، جرام...)
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; } // آخر سعر شراء
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // الصنف متخزن في مخزن معين
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        // لكل صنف خام يمكن استعماله في عدة تركيبات
        public ICollection<CompositionRawItem> CompositionRawItems { get; set; }
    }
}
