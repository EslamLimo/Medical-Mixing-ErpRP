using System;

namespace MedicalMixingERP.Api.Models
{
    public class ShippingTransaction
    {
        public int Id { get; set; }
        public int ShippingCompanyId { get; set; }
        public ShippingCompany ShippingCompany { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public int? SupplierCustomerId { get; set; } // العميل المستلم أو المورد المُرسل
        public SupplierCustomer SupplierCustomer { get; set; }

        public decimal ShippingCost { get; set; }
        public DateTime ShippingDate { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
    }
}
