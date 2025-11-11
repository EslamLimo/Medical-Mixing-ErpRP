namespace MedicalMixingERP.Models.DTO
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
    }
}
