namespace MedicalMixingERP.Api.Models
{
    public class CompositionRawItem
    {
        public int Id { get; set; }
        public int CompositionId { get; set; }
        public Composition Composition { get; set; }

        public int RawItemId { get; set; }
        public RawItem RawItem { get; set; }

        public decimal Quantity { get; set; } // الكمية المطلوبة من المادة الخام في هذه التركيبة
    }
}
