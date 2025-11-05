using System;

namespace MedicalMixingERP.Api.Models
{
    public class PackingTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string PackingType { get; set; } // نوع/حجم العبوة
        public int Quantity { get; set; }
        public decimal PackingCost { get; set; } // تكلفة التعبئة والمستلزمات
        public DateTime PackingDate { get; set; }
    }
}
