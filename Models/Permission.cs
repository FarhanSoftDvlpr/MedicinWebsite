namespace MEDICINE.WEB.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PermissionKey { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation Property

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}