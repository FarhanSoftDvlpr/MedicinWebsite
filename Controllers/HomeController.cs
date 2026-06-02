using MEDICINE.WEB.Data;
using MEDICINE.WEB.Models;
using MEDICINE.WEB.ViewModels.Home;
using MEDICINE.WEB.ViewModels.Testimonials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MEDICINE.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel
            {
                Banners = await _context.Banners
                    .Where(x => !x.IsDeleted && x.IsActive)
                    .OrderBy(x => x.SortOrder)
                    .ThenByDescending(x => x.Id)
                    .Take(5)
                    .ToListAsync(),

                FeaturedTreatments = await _context.Treatments
                    .Where(x => !x.IsDeleted && x.IsActive)
                    .OrderBy(x => x.SortOrder)
                    .ThenByDescending(x => x.Id)
                    .Take(6)
                    .ToListAsync(),

                FeaturedHospitals = await _context.Hospitals
                    .Where(x => !x.IsDeleted && x.IsActive && x.IsFeatured)
                    .OrderBy(x => x.SortOrder)
                    .ThenByDescending(x => x.Id)
                    .Take(6)
                    .ToListAsync(),

                FeaturedDoctors = await _context.Doctors
                    .Where(x => !x.IsDeleted && x.IsActive && x.IsFeatured)
                    .OrderBy(x => x.SortOrder)
                    .ThenByDescending(x => x.Id)
                    .Take(6)
                    .ToListAsync(),

                FeaturedTestimonials = await _context.Testimonials
                    .Where(x =>
                        x.IsFeatured &&
                        x.IsActive &&
                        !x.IsDeleted)
                    .OrderBy(x => x.SortOrder)
                    .ThenByDescending(x => x.Id)
                    .Take(6)
                    .Select(x => new PublicTestimonialViewModel
                    {
                        PatientNameEn = x.PatientNameEn,
                        PatientNameAr = x.PatientNameAr,
                        CountryEn = x.CountryEn,
                        CountryAr = x.CountryAr,
                        TreatmentNameEn = x.TreatmentNameEn,
                        TreatmentNameAr = x.TreatmentNameAr,
                        ImagePath = x.ImagePath,
                        VideoUrl = x.VideoUrl,
                        StoryEn = x.StoryEn,
                        StoryAr = x.StoryAr,
                        Rating = x.Rating
                    })
                    .ToListAsync(),

                Faqs = await _context.Faqs
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.SortOrder)
                    .ThenByDescending(x => x.Id)
                    .Take(10)
                    .ToListAsync()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}