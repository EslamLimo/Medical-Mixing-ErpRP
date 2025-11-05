using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class ShippingCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // جميع الحركات أو العمليات الخاصة بالشحن
        public ICollection<ShippingTransaction> ShippingTransactions { get; set; }
    }
}
