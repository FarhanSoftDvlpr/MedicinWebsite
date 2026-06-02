using MEDICINE.WEB.Data;
using MEDICINE.WEB.Models;
using System.Security.Claims;

namespace MEDICINE.WEB.Helpers
{
    public static class AuditLogHelper
    {
        public static async Task LogAsync(
            ApplicationDbContext context,
            ClaimsPrincipal user,
            string action,
            string moduleName,
            string description,
            string? ipAddress = null)
        {
            int? adminUserId = null;
            string? adminUserName = null;

            var idClaim = user.FindFirst("AdminUserId");
            var nameClaim = user.FindFirst(ClaimTypes.Name);

            if (idClaim != null)
            {
                adminUserId = int.Parse(idClaim.Value);
            }

            if (nameClaim != null)
            {
                adminUserName = nameClaim.Value;
            }

            var auditLog = new AuditLog
            {
                AdminUserId = adminUserId,
                AdminUserName = adminUserName,
                Action = action,
                ModuleName = moduleName,
                Description = description,
                IpAddress = ipAddress,
                CreatedAt = DateTime.UtcNow
            };

            context.AuditLogs.Add(auditLog);

            await context.SaveChangesAsync();
        }
    }
}