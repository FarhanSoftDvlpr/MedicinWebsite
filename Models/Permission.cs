using MEDICINE.WEB.Common;

namespace MEDICINE.WEB.Models
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public string PermissionKey { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        // Navigation Property

        public ICollection<RolePermission> RolePermissions
        {
            get;
            set;
        } = new List<RolePermission>();
    }
}