using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Cost { get; set; } // متوسط أو آخر تكلفة
        public bool IsPacked { get; set; } // هل هو معبأ أو لا
        public DateTime CreatedAt { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        // علاقة بالتركيبة الأساسية لو كان منتج مركب
        public int? CompositionId { get; set; }
        public Composition Composition { get; set; }

        // العُبوات التي أنتج منها
        public ICollection<PackingTransaction> PackingTransactions { get; set; }
    }
}
