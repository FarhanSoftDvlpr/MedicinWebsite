using MEDICINE.WEB.Models;
using MEDICINE.WEB.ViewModels.Testimonials;
namespace MEDICINE.WEB.ViewModels.Home
{
    public class HomePageViewModel
    {
        public List<Banner> Banners { get; set; } = new();

        public List<Treatment> FeaturedTreatments { get; set; } = new();

        public List<Hospital> FeaturedHospitals { get; set; } = new();

        public List<Doctor> FeaturedDoctors { get; set; } = new();

        public List<PublicTestimonialViewModel> FeaturedTestimonials { get; set; }  = new();

        public List<Faq> Faqs { get; set; } = new();
    }
}