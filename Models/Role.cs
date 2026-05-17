using MEDICINE.WEB.Common;

namespace MEDICINE.WEB.Models
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RoleKey { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties

        public ICollection<RolePermission> RolePermissions { get; set; }

        public ICollection<AdminUserRole> AdminUserRoles { get; set; }

    }
}