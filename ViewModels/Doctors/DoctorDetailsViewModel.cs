using MEDICINE.WEB.Models;

namespace MEDICINE.WEB.ViewModels.Doctors
{
    public class DoctorDetailsViewModel
    {
        public Doctor Doctor { get; set; }

        public List<Treatment> Treatments { get; set; }
            = new List<Treatment>();

        public PublicInquiryViewModel InquiryForm { get; set; }
            = new PublicInquiryViewModel();
    }
}