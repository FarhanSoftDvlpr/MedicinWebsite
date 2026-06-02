using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace MEDICINE.WEB.Filters
{
    public class PermissionAuthorizationFilter
        : IAuthorizationFilter
    {
        private readonly string _permission;

        public PermissionAuthorizationFilter(
            string permission
        )
        {
            _permission = permission;
        }

        public void OnAuthorization(
            AuthorizationFilterContext context
        )
        {
            /*
                CHECK LOGIN
            */

            if (!context.HttpContext.User.Identity
                .IsAuthenticated)
            {
                context.Result =
                    new RedirectToActionResult(
                        "Login",
                        "Account",
                        new { area = "Admin" }
                    );

                return;
            }

            /*
                SUPER ADMIN BYPASS
            */

            bool isSuperAdmin = context
                .HttpContext
                .User
                .Claims
                .Any(x =>
                    x.Type == ClaimTypes.Role
                    && x.Value == "SUPER_ADMIN"
                );

            if (isSuperAdmin)
            {
                return;
            }

            /*
                CHECK PERMISSION
            */

            bool hasPermission = context
                .HttpContext
                .User
                .Claims
                .Any(x =>
                    x.Type == "Permission"
                    && x.Value == _permission
                );

            if (!hasPermission)
            {
                context.Result =
                    new RedirectToActionResult(
                        "AccessDenied",
                        "Account",
                        new { area = "Admin" }
                    );
            }
        }
    }
}