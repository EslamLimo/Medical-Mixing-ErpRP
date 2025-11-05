using System;

namespace MedicalMixingERP.Api.Models
{
    public class Commission
    {
        public int Id { get; set; }
        public int SalesRepId { get; set; }
        public SalesRep SalesRep { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public decimal Target { get; set; }
        public decimal Amount { get; set; }
        public DateTime CommissionDate { get; set; }
        public string Note { get; set; }
    }
}
