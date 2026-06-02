using MEDICINE.WEB.Models.Admin;

namespace MEDICINE.WEB.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        public int? AdminUserId { get; set; }

        public string? AdminUserName { get; set; }

        public string? Action { get; set; }

        public string? ModuleName { get; set; }

        public string? Description { get; set; }

        public string? IpAddress { get; set; }

        public DateTime CreatedAt { get; set; }

        public AdminUser? AdminUser { get; set; }
    }
}