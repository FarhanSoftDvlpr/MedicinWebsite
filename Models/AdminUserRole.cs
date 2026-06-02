using MEDICINE.WEB.Models.Admin;

namespace MEDICINE.WEB.Models
{
    public class AdminUserRole
    {
        public int AdminUserId { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }
            = DateTime.UtcNow;

        public virtual AdminUser AdminUser { get; set; }

        public virtual Role Role { get; set; }
    }
}