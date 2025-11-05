using System;

namespace MedicalMixingERP.Api.Models
{
    public class InventoryTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; } // شراء، إنتاج، صرف، تحويل...
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int? RawItemId { get; set; }
        public RawItem RawItem { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public decimal Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Note { get; set; }
    }
}
