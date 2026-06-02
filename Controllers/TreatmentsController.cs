using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels;
using MEDICINE.WEB.ViewModels.Treatments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Controllers
{
    public class TreatmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreatmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var treatments = await _context.Treatments
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.NameEn)
                .ToListAsync();

            return View(treatments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var treatment = await _context.Treatments
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive && !x.IsDeleted);

            if (treatment == null)
            {
                return NotFound();
            }

            var model = new TreatmentDetailsViewModel
            {
                Treatment = treatment,
                InquiryForm = await BuildInquiryForm(treatment.Id)
            };

            return View(model);
        }

        [HttpGet("/treatments/{slug}")]
        public async Task<IActionResult> DetailsBySlug(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            var treatment = await _context.Treatments
                .FirstOrDefaultAsync(x => x.Slug == slug && x.IsActive && !x.IsDeleted);

            if (treatment == null)
            {
                return NotFound();
            }

            var model = new TreatmentDetailsViewModel
            {
                Treatment = treatment,
                InquiryForm = await BuildInquiryForm(treatment.Id)
            };

            return View("Details", model);
        }

        private async Task<PublicInquiryViewModel> BuildInquiryForm(int treatmentId)
        {
            return new PublicInquiryViewModel
            {
                TreatmentId = treatmentId,
                SourcePage = "Treatment Details",

                Countries = await _context.Countries
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.NameEn)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.NameEn
                    })
                    .ToListAsync(),

                Treatments = await _context.Treatments
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.NameEn)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.NameEn
                    })
                    .ToListAsync()
            };
        }
    }
}