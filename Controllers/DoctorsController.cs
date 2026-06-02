using MEDICINE.WEB.Data;
using MEDICINE.WEB.ViewModels;
using MEDICINE.WEB.ViewModels.Doctors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _context.Doctors
                .Include(x => x.Hospital)
                .Include(x => x.Country)
                .Include(x => x.State)
                .Include(x => x.City)
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.FullNameEn)
                .ToListAsync();

            return View(doctors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _context.Doctors
                .Include(x => x.Hospital)
                .Include(x => x.Country)
                .Include(x => x.State)
                .Include(x => x.City)
                .Include(x => x.DoctorTreatments)
                    .ThenInclude(x => x.Treatment)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive && !x.IsDeleted);

            if (doctor == null)
            {
                return NotFound();
            }

            var treatments = doctor.DoctorTreatments
                .Where(x => x.Treatment != null && x.Treatment.IsActive && !x.Treatment.IsDeleted)
                .Select(x => x.Treatment)
                .ToList();

            var model = new DoctorDetailsViewModel
            {
                Doctor = doctor,
                Treatments = treatments,
                InquiryForm = await BuildInquiryForm(doctor.Id)
            };

            return View(model);
        }

        [HttpGet("/doctors/{slug}")]
        public async Task<IActionResult> DetailsBySlug(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(x => x.Hospital)
                .Include(x => x.Country)
                .Include(x => x.State)
                .Include(x => x.City)
                .Include(x => x.DoctorTreatments)
                    .ThenInclude(x => x.Treatment)
                .FirstOrDefaultAsync(x => x.Slug == slug && x.IsActive && !x.IsDeleted);

            if (doctor == null)
            {
                return NotFound();
            }

            var treatments = doctor.DoctorTreatments
                .Where(x => x.Treatment != null && x.Treatment.IsActive && !x.Treatment.IsDeleted)
                .Select(x => x.Treatment)
                .ToList();

            var model = new DoctorDetailsViewModel
            {
                Doctor = doctor,
                Treatments = treatments,
                InquiryForm = await BuildInquiryForm(doctor.Id)
            };

            return View("Details", model);
        }

        private async Task<PublicInquiryViewModel> BuildInquiryForm(int doctorId)
        {
            return new PublicInquiryViewModel
            {
                DoctorId = doctorId,
                SourcePage = "Doctor Details",

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
                    .ToListAsync(),

                Doctors = await _context.Doctors
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.FullNameEn)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.FullNameEn
                    })
                    .ToListAsync()
            };
        }
    }
}