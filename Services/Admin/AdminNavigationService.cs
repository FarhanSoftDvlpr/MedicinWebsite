using MEDICINE.WEB.Models.Admin.Navigation;
using System.Security.Claims;

namespace MEDICINE.WEB.Services.Admin
{
    public class AdminNavigationService
    {
        public List<AdminMenuItem> GetMenu(
            ClaimsPrincipal user
        )
        {
            List<AdminMenuItem> menu =
                new List<AdminMenuItem>();

            menu.Add(new AdminMenuItem
            {
                Title = "Dashboard",
                ArabicTitle = "لوحة التحكم",
                Icon = "fas fa-tachometer-alt",
                Url = "/Admin/Dashboard",
                PermissionKey = "DASHBOARD_VIEW"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Admin Users",
                ArabicTitle = "المشرفين",
                Icon = "fas fa-users-cog",
                Url = "/Admin/AdminUsers",
                PermissionKey = "USER_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Roles",
                ArabicTitle = "الأدوار",
                Icon = "fas fa-user-shield",
                Url = "/Admin/Roles",
                PermissionKey = "USER_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Blogs",
                ArabicTitle = "المدونات",
                Icon = "fas fa-blog",
                Url = "/Admin/Blogs",
                PermissionKey = "BLOG_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Doctors",
                ArabicTitle = "الأطباء",
                Icon = "fas fa-user-md",
                Url = "/Admin/Doctors",
                PermissionKey = "DOCTOR_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Countries",
                Url = "/Admin/Countries",
                Icon = "fa fa-globe",
                PermissionKey = "COUNTRY_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "States",
                Url = "/Admin/States",
                Icon = "fa fa-map",
                PermissionKey = "STATE_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Cities",
                Url = "/Admin/Cities",
                Icon = "fa fa-map-marker",
                PermissionKey = "CITY_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Inquiries",
                ArabicTitle = "الاستفسارات",
                Icon = "fas fa-envelope",
                Url = "/Admin/Inquiries",
                PermissionKey = "INQUIRY_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Banners",
                Url = "/Admin/Banners",
                Icon = "fa fa-image",
                PermissionKey = "BANNER_MANAGE"
            });
            menu.Add(new AdminMenuItem
            {
                Title = "Treatments",
                Url = "/Admin/Treatments",
                Icon = "fa fa-stethoscope",
                PermissionKey = "TREATMENT_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "Hospitals",
                Url = "/Admin/Hospitals",
                Icon = "fa fa-hospital",
                PermissionKey = "HOSPITAL_MANAGE"
            });

            menu.Add(new AdminMenuItem
            {
                Title = "CMS Pages",
                Url = "/Admin/CmsPages",
                Icon = "fa fa-file-alt",
                PermissionKey = "CMSPAGE_MANAGE"
            });

            foreach (var item in menu)
            {
                item.IsVisible =
                    HasPermission(user, item.PermissionKey);
            }

            return menu
                .Where(x => x.IsVisible)
                .ToList();
        }

        private bool HasPermission(
            ClaimsPrincipal user,
            string permission
        )
        {
            if (user.Claims.Any(x =>
                x.Type == ClaimTypes.Role
                && x.Value == "SUPER_ADMIN"))
            {
                return true;
            }

            return user.Claims.Any(x =>
                x.Type == "Permission"
                && x.Value == permission);
        }
    }
}