namespace MEDICINE.WEB.Models
{
    public class RolePermission
    {
        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public DateTime CreatedAt { get; set; }
            = DateTime.UtcNow;

        public virtual Role Role { get; set; }

        public virtual Permission Permission { get; set; }
    }
}