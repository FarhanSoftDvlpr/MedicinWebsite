using MEDICINE.WEB.Models;

namespace MEDICINE.WEB.ViewModels.Treatments
{
    public class TreatmentDetailsViewModel
    {
        public Treatment Treatment { get; set; }
        public PublicInquiryViewModel InquiryForm { get; set; } = new PublicInquiryViewModel();
    }
}