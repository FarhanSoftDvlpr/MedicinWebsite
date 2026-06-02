using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels.Menus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.ViewComponents
{
    public class PublicMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public PublicMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menus = await _context.Menus
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.Id)
                .Select(x => new PublicMenuViewModel
                {
                    Id = x.Id,
                    ParentMenuId = x.ParentMenuId,
                    TitleEn = x.TitleEn,
                    TitleAr = x.TitleAr,
                    Url = x.Url,
                    OpenInNewTab = x.OpenInNewTab
                })
                .ToListAsync();

            var parentMenus = menus
                .Where(x => x.ParentMenuId == null)
                .ToList();

            foreach (var parent in parentMenus)
            {
                parent.ChildMenus = menus
                    .Where(x => x.ParentMenuId == parent.Id)
                    .ToList();
            }

            return View(parentMenus);
        }
    }
}