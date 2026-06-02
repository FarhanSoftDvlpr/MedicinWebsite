using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels.Testimonials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestimonialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("testimonials")]
        public async Task<IActionResult> Index()
        {
            var testimonials = await _context.Testimonials
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.SortOrder)
                .ThenByDescending(x => x.Id)
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
                .ToListAsync();

            ViewData["Title"] = "Patient Success Stories";

            return View(testimonials);
        }
    }
}