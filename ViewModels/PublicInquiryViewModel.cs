using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.ViewModels
{
    public class PublicInquiryViewModel
    {
        [Required]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [Display(Name = "State")]
        public int? StateId { get; set; }

        [Display(Name = "City")]
        public int? CityId { get; set; }

        public int? TreatmentId { get; set; }
        public int? HospitalId { get; set; }
        public int? DoctorId { get; set; }

        [Display(Name = "Message")]
        public string? Message { get; set; }

        public string? SourcePage { get; set; }

        public List<SelectListItem> Countries { get; set; } = new();
        public List<SelectListItem> Treatments { get; set; } = new();
        public List<SelectListItem> Hospitals { get; set; } = new();
        public List<SelectListItem> Doctors { get; set; } = new();

    }
}