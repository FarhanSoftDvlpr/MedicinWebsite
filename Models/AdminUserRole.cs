using MEDICINE.WEB.Models.Admin;

namespace MEDICINE.WEB.Models
{
    public class AdminUserRole
    {
        public int Id { get; set; }

        public int AdminUserId { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual AdminUser AdminUser { get; set; }

        public virtual Role Role { get; set; }
    }
}