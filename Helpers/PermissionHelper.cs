using System.Security.Claims;

namespace MEDICINE.WEB.Helpers
{
    public static class PermissionHelper
    {
        public static bool HasPermission(
            ClaimsPrincipal user,
            string permission
        )
        {
            if (user == null)
            {
                return false;
            }

            // SUPER ADMIN BYPASS
            if (user.Claims.Any(x =>
                x.Type == ClaimTypes.Role
                && x.Value == "SUPER_ADMIN"))
            {
                return true;
            }

            // NORMAL PERMISSION CHECK
            return user.Claims.Any(x =>
                x.Type == "Permission"
                && x.Value == permission);
        }
    }
}