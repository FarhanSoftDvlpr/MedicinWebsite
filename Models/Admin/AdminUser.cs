using MEDICINE.WEB.Common;
using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models.Admin
{
    public class AdminUser : BaseEntity
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string? MobileNumber { get; set; }

        public string? ProfileImage { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsLocked { get; set; } = false;

        public int FailedLoginAttempts { get; set; } = 0;

        public DateTime? LastLoginAt { get; set; }

        public string? LastLoginIP { get; set; }

        public DateTime? LastPasswordChangedAt { get; set; }

        public bool ForcePasswordChange { get; set; } = false;

        public string? Department { get; set; }

        public string? Designation { get; set; }

        public string PreferredLanguage { get; set; } = "en";

        public string? TimeZone { get; set; }

        public string? Notes { get; set; }

        // Navigation

        public virtual ICollection<AdminUserRole> AdminUserRoles
        {
            get;
            set;
        } = new List<AdminUserRole>();
    }
}