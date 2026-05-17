using MEDICINE.WEB.Areas.Admin.ViewModels;
using MEDICINE.WEB.Data;
using MEDICINE.WEB.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MEDICINE.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.AdminUsers
                .FirstOrDefaultAsync(x =>
                    x.Email == model.Email
                    && x.IsDeleted == false
                    && x.IsActive == true);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            PasswordHelper passwordHelper = new PasswordHelper();

            bool isPasswordValid = passwordHelper.VerifyPassword(
                user.PasswordHash,
                model.Password
            );

            if (!isPasswordValid)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            // LOAD USER ROLES
            var userRoles = await _context.AdminUserRoles
                .Include(x => x.Role)
                .Where(x => x.AdminUserId == user.Id)
                .ToListAsync();

            // GET ROLE IDS
            var roleIds = userRoles
                .Select(x => x.RoleId)
                .ToList();

            // LOAD ROLE PERMISSIONS
            var permissions = await _context.RolePermissions
                .Include(x => x.Permission)
                .ToListAsync();

            permissions = permissions
                .Where(x => roleIds.Contains(x.RoleId))
                .ToList();

            // CREATE CLAIMS
            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.Name,
                    user.FullName
                ),

                new Claim(
                    ClaimTypes.Email,
                    user.Email
                ),

                new Claim(
                    "AdminUserId",
                    user.Id.ToString()
                )
            };

            // ADD PERMISSION CLAIMS
            foreach (var permission in permissions
                .GroupBy(x => x.Permission.PermissionKey)
                .Select(x => x.First()))
            {
                claims.Add(
                    new Claim(
                        "Permission",
                        permission.Permission.PermissionKey
                    )
                );
            }

            // ADD ROLE CLAIMS
            foreach (var role in userRoles)
            {
                claims.Add(
                    new Claim(
                        ClaimTypes.Role,
                        role.Role.RoleKey
                    )
                );
            }

            // CREATE IDENTITY
            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            // UPDATE LOGIN INFO
            user.LastLoginAt = DateTime.UtcNow;

            user.LastLoginIP = HttpContext
                .Connection
                .RemoteIpAddress?
                .ToString();

            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // SIGN IN
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,

                    ExpiresUtc = model.RememberMe
                        ? DateTime.UtcNow.AddDays(30)
                        : DateTime.UtcNow.AddHours(8)
                }
            );

            return RedirectToAction(
                "Index",
                "Dashboard",
                new { area = "Admin" }
            );
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}