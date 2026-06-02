using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels;
using MEDICINE.WEB.ViewModels.Hospitals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HospitalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var hospitals = await _context.Hospitals
                .Include(x => x.CountryMaster)
                .Include(x => x.StateMaster)
                .Include(x => x.CityMaster)
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.NameEn)
                .ToListAsync();

            return View(hospitals);
        }

        public async Task<IActionResult> Details(int id)
        {
            var hospital = await _context.Hospitals
                .Include(x => x.CountryMaster)
                .Include(x => x.StateMaster)
                .Include(x => x.CityMaster)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive && !x.IsDeleted);

            if (hospital == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .Where(x => x.HospitalId == hospital.Id && x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.FullNameEn)
                .ToListAsync();

            var model = new HospitalDetailsViewModel
            {
                Hospital = hospital,
                Doctors = doctors,
                InquiryForm = await BuildInquiryForm(hospital.Id)
            };

            return View(model);
        }

        [HttpGet("/hospitals/{slug}")]
        public async Task<IActionResult> DetailsBySlug(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            var hospital = await _context.Hospitals
                .Include(x => x.CountryMaster)
                .Include(x => x.StateMaster)
                .Include(x => x.CityMaster)
                .FirstOrDefaultAsync(x => x.Slug == slug && x.IsActive && !x.IsDeleted);

            if (hospital == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .Where(x => x.HospitalId == hospital.Id && x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.FullNameEn)
                .ToListAsync();

            var model = new HospitalDetailsViewModel
            {
                Hospital = hospital,
                Doctors = doctors,
                InquiryForm = await BuildInquiryForm(hospital.Id)
            };

            return View("Details", model);
        }

        private async Task<PublicInquiryViewModel> BuildInquiryForm(int hospitalId)
        {
            return new PublicInquiryViewModel
            {
                HospitalId = hospitalId,
                SourcePage = "Hospital Details",

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
                    .ToListAsync(),

                Hospitals = await _context.Hospitals
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