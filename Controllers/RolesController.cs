using MEDICINE.WEB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MEDICINE.WEB.Areas.Admin.ViewModels;
using MEDICINE.WEB.Models;

namespace MEDICINE.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _context.Roles
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var role = await _context.Roles
                .FirstOrDefaultAsync(x => x.Id == id);

            if (role == null)
            {
                return NotFound();
            }

            var assignedPermissionIds = await _context.RolePermissions
                .Where(x => x.RoleId == id)
                .Select(x => x.PermissionId)
                .ToListAsync();

            var allPermissions = await _context.Permissions
                .OrderBy(x => x.Category)
                .ThenBy(x => x.Name)
                .ToListAsync();

            var model = new RoleEditViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                RoleKey = role.RoleKey
            };

            model.Permissions = allPermissions.Select(permission => new PermissionCheckboxViewModel
            {
                PermissionId = permission.Id,
                PermissionName = permission.Name,
                PermissionKey = permission.PermissionKey,
                Category = permission.Category,
                IsSelected = assignedPermissionIds.Contains(permission.Id)
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (role == null)
            {
                return NotFound();
            }

            role.Name = model.Name;
            role.Description = model.Description;

            await _context.SaveChangesAsync();

            /*
                REMOVE OLD PERMISSIONS
            */

            var oldPermissions = await _context.RolePermissions
                .Where(x => x.RoleId == role.Id)
                .ToListAsync();

            _context.RolePermissions.RemoveRange(oldPermissions);

            await _context.SaveChangesAsync();

            /*
                ADD NEW PERMISSIONS
            */

            var selectedPermissions = model.Permissions
                .Where(x => x.IsSelected)
                .Select(x => new RolePermission
                {
                    RoleId = role.Id,
                    PermissionId = x.PermissionId
                })
                .ToList();

            if (selectedPermissions.Any())
            {
                await _context.RolePermissions.AddRangeAsync(selectedPermissions);
                await _context.SaveChangesAsync();
            }

            TempData["Success"] = "Role updated successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}