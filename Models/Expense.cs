using System;

namespace MedicalMixingERP.Api.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string ExpenseType { get; set; } // نوع المصروف (عمالة، كهرباء ...الخ)
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int? ProductId { get; set; } // اختياري (للوصل بتوزيع المصروف على منتج معين)
        public Product Product { get; set; }
        public string Note { get; set; }
    }
}
