using System;
using System.Collections.Generic;

namespace MedicalMixingERP.Api.Models
{
    public class SupplierCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // يمكن أن يكون له أكثر من حساب وحركة مالية
        public ICollection<AccountTransaction> AccountTransactions { get; set; }
    }
}
