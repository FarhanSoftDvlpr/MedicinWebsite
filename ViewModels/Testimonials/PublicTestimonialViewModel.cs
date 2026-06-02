namespace MEDICINE.WEB.ViewModels.Testimonials
{
    public class PublicTestimonialViewModel
    {
        public string PatientNameEn { get; set; }

        public string PatientNameAr { get; set; }

        public string? CountryEn { get; set; }

        public string? CountryAr { get; set; }

        public string? TreatmentNameEn { get; set; }

        public string? TreatmentNameAr { get; set; }

        public string? ImagePath { get; set; }

        public string? VideoUrl { get; set; }

        public string StoryEn { get; set; }

        public string StoryAr { get; set; }

        public int Rating { get; set; }
    }
}