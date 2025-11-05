using System;

namespace MedicalMixingERP.Api.Models
{
    public class AccountTransaction
    {
        public int Id { get; set; }
        public int SupplierCustomerId { get; set; }
        public SupplierCustomer SupplierCustomer { get; set; }

        public decimal Debit { get; set; } // مدين (مبلغ على العميل/المورد)
        public decimal Credit { get; set; } // دائن (مبلغ للنظام)
        public decimal? WalletFee { get; set; } // مصاريف تحويل إلكترونية
        public string WalletType { get; set; } // نوع المحفظة الإلكترونية "InstaPay"
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public bool IsWalletTransaction { get; set; }
    }
}
