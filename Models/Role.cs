using MEDICINE.WEB.Common;

namespace MEDICINE.WEB.Models
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string RoleKey { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        // Navigation Properties

        public ICollection<RolePermission> RolePermissions
        {
            get;
            set;
        } = new List<RolePermission>();

        public ICollection<AdminUserRole> AdminUserRoles
        {
            get;
            set;
        } = new List<AdminUserRole>();
    }
}