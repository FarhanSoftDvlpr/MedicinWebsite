using MEDICINE.WEB.Data;
using MEDICINE.WEB.Models;
using MEDICINE.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MEDICINE.WEB.Controllers
{
    public class PublicInquiryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicInquiryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            var model = new PublicInquiryViewModel
            {
                SourcePage = "Contact Page",
                Countries = await GetCountriesAsync(),
                Treatments = await GetTreatmentsAsync(),
                Hospitals = await GetHospitalsAsync(),
                Doctors = await GetDoctorsAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(PublicInquiryViewModel model)
        {
            model.SourcePage = "Contact Page";

            if (!ModelState.IsValid)
            {
                model.Countries = await GetCountriesAsync();
                model.Treatments = await GetTreatmentsAsync();
                model.Hospitals = await GetHospitalsAsync();
                model.Doctors = await GetDoctorsAsync();

                return View(model);
            }

            await SaveInquiryAsync(model);

            TempData["Success"] = "Your inquiry has been submitted successfully. Our team will contact you soon.";

            return RedirectToAction(nameof(Contact));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(PublicInquiryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill all required fields.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            await SaveInquiryAsync(model);

            TempData["Success"] = "Your inquiry has been submitted successfully. Our team will contact you soon.";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuickSubmit(PublicInquiryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill required details.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            await SaveInquiryAsync(model);

            TempData["Success"] = "Your inquiry has been submitted successfully. Our team will contact you soon.";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuickCallback(string patientName, string mobileNumber, int? countryId)
        {
            if (string.IsNullOrWhiteSpace(patientName) || string.IsNullOrWhiteSpace(mobileNumber))
            {
                TempData["Error"] = "Please enter your name and mobile number.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            var inquiry = new Inquiry
            {
                PatientName = patientName,
                MobileNumber = mobileNumber,
                CountryId = countryId,
                InquirySource = "Quick Callback Request",
                InquiryStatus = "New",
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };

            _context.Inquiries.Add(inquiry);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Callback request submitted successfully.";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public async Task<JsonResult> GetStatesByCountry(int countryId)
        {
            var states = await _context.States
                .Where(x => x.CountryId == countryId && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.NameEn)
                .Select(x => new
                {
                    id = x.Id,
                    name = x.NameEn
                })
                .ToListAsync();

            return Json(states);
        }

        [HttpGet]
        public async Task<JsonResult> GetCitiesByState(int stateId)
        {
            var cities = await _context.Cities
                .Where(x => x.StateId == stateId && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.NameEn)
                .Select(x => new
                {
                    id = x.Id,
                    name = x.NameEn
                })
                .ToListAsync();

            return Json(cities);
        }

        private async Task SaveInquiryAsync(PublicInquiryViewModel model)
        {
            var inquiry = new Inquiry
            {
                PatientName = model.PatientName,
                Email = model.Email,
                MobileNumber = model.MobileNumber,
                CountryId = model.CountryId,
                StateId = model.StateId,
                CityId = model.CityId,
                TreatmentId = model.TreatmentId,
                HospitalId = model.HospitalId,
                DoctorId = model.DoctorId,
                Message = model.Message,
                InquirySource = model.SourcePage ?? "Website Inquiry",
                InquiryStatus = "New",
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };

            _context.Inquiries.Add(inquiry);
            await _context.SaveChangesAsync();
        }

        private async Task<List<SelectListItem>> GetCountriesAsync()
        {
            return await _context.Countries
                .Where(x => !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.NameEn)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameEn
                })
                .ToListAsync();
        }

        private async Task<List<SelectListItem>> GetTreatmentsAsync()
        {
            return await _context.Treatments
                .Where(x => !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.NameEn)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameEn
                })
                .ToListAsync();
        }

        private async Task<List<SelectListItem>> GetHospitalsAsync()
        {
            return await _context.Hospitals
                .Where(x => !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.NameEn)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameEn
                })
                .ToListAsync();
        }

        private async Task<List<SelectListItem>> GetDoctorsAsync()
        {
            return await _context.Doctors
                .Where(x => !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.FullNameEn)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.FullNameEn
                })
                .ToListAsync();
        }
    }
}