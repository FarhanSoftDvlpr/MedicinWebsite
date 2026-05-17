using MEDICINE.WEB.Common;

namespace MEDICINE.WEB.Models.Admin
{
    public class AdminUser : BaseEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? MobileNumber { get; set; }

        public string? ProfileImage { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? LastLoginAt { get; set; }

        public string? LastLoginIP { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsLocked { get; set; }


        public virtual ICollection<AdminUserRole> AdminUserRoles
        {
            get;
            set;
        }
    }
}