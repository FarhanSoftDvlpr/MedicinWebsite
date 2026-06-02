using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels.MedicalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Controllers
{
    public class MedicalServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("services")]
        public async Task<IActionResult> Index()
        {
            var services = await _context.MedicalServices
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.SortOrder)
                .ThenByDescending(x => x.Id)
                .Select(x => new PublicMedicalServiceListViewModel
                {
                    TitleEn = x.TitleEn,
                    TitleAr = x.TitleAr,
                    Slug = x.Slug,
                    ShortDescriptionEn = x.ShortDescriptionEn,
                    ShortDescriptionAr = x.ShortDescriptionAr,
                    ImagePath = x.ImagePath,
                    IconClass = x.IconClass
                })
                .ToListAsync();

            ViewData["Title"] = "Medical Tourism Services";

            return View(services);
        }

        [HttpGet]
        [Route("service/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return NotFound();
            }

            var service = await _context.MedicalServices
                .Where(x =>
                    x.Slug == slug &&
                    x.IsActive &&
                    !x.IsDeleted)
                .Select(x => new PublicMedicalServiceDetailViewModel
                {
                    TitleEn = x.TitleEn,
                    TitleAr = x.TitleAr,
                    Slug = x.Slug,
                    ShortDescriptionEn = x.ShortDescriptionEn,
                    ShortDescriptionAr = x.ShortDescriptionAr,
                    DescriptionEn = x.DescriptionEn,
                    DescriptionAr = x.DescriptionAr,
                    ImagePath = x.ImagePath,
                    IconClass = x.IconClass,
                    MetaTitleEn = x.MetaTitleEn,
                    MetaDescriptionEn = x.MetaDescriptionEn
                })
                .FirstOrDefaultAsync();

            if (service == null)
            {
                return NotFound();
            }

            ViewData["Title"] = !string.IsNullOrWhiteSpace(service.MetaTitleEn)
                ? service.MetaTitleEn
                : service.TitleEn;

            ViewData["MetaDescription"] = service.MetaDescriptionEn;

            return View(service);
        }
    }
}