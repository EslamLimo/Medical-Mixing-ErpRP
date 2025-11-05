using System;

namespace MedicalMixingERP.Api.Models
{
    public class AuditTrail
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public int RecordId { get; set; }
        public string ActionType { get; set; } // إضافة، تعديل، حذف
        public string UserName { get; set; }
        public DateTime ActionDate { get; set; }
        public string Details { get; set; }
    }
}
