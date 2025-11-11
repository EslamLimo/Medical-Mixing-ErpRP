namespace MedicalMixingERP.Models.DTO
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string MainColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Lang { get; set; }
        public List<string> Roles { get; set; }
    }
}
