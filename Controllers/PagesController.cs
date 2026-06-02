using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels.CmsPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Controllers
{
    public class PagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("pages/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return NotFound();
            }

            var page = await _context.CmsPages
                .Where(x =>
                    x.Slug == slug
                    && x.IsActive == true
                    && x.IsDeleted == false)
                .Select(x => new PublicCmsPageViewModel
                {
                    TitleEn = x.TitleEn,
                    TitleAr = x.TitleAr,
                    DescriptionEn = x.DescriptionEn,
                    DescriptionAr = x.DescriptionAr,
                    MetaTitleEn = x.MetaTitleEn,
                    MetaDescriptionEn = x.MetaDescriptionEn,
                    Slug = x.Slug
                })
                .FirstOrDefaultAsync();

            if (page == null)
            {
                return NotFound();
            }

            ViewData["Title"] = !string.IsNullOrWhiteSpace(page.MetaTitleEn)
                ? page.MetaTitleEn
                : page.TitleEn;

            ViewData["MetaDescription"] = page.MetaDescriptionEn;

            return View(page);
        }
    }
}