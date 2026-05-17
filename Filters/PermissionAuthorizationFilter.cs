using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MEDICINE.WEB.Filters
{
    public class PermissionAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _permission;

        public PermissionAuthorizationFilter(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(
            AuthorizationFilterContext context
        )
        {
            bool hasPermission =
                context.HttpContext.User.Claims.Any(x =>
                    x.Type == "Permission"
                    &&
                    x.Value == _permission
                );

            if (!hasPermission)
            {
                context.Result = new RedirectToActionResult(
                    "AccessDenied",
                    "Account",
                    new { area = "Admin" }
                );
            }
        }
    }
}