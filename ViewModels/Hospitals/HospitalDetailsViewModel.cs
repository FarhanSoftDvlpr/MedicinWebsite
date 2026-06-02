using MEDICINE.WEB.Models;

namespace MEDICINE.WEB.ViewModels.Hospitals
{
    public class HospitalDetailsViewModel
    {
        public Hospital Hospital { get; set; }

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        public PublicInquiryViewModel InquiryForm { get; set; }
            = new PublicInquiryViewModel();
    }
}