namespace MedicalMixingERP.Api.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }   // <-- virtual, NOT required
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }   // <-- virtual, NOT required


    }
}
