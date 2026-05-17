using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Areas.Admin.ViewModels
{
    public class RoleEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string RoleKey { get; set; }

        public List<PermissionCheckboxViewModel> Permissions { get; set; }
            = new List<PermissionCheckboxViewModel>();
    }

    public class PermissionCheckboxViewModel
    {
        public int PermissionId { get; set; }

        public string PermissionName { get; set; }

        public string PermissionKey { get; set; }

        public string Category { get; set; }

        public bool IsSelected { get; set; }
    }
}