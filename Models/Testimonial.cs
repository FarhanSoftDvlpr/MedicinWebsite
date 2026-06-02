using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string PatientNameEn { get; set; }

        [Required]
        [MaxLength(200)]
        public string PatientNameAr { get; set; }

        [MaxLength(200)]
        public string? CountryEn { get; set; }

        [MaxLength(200)]
        public string? CountryAr { get; set; }

        [MaxLength(250)]
        public string? TreatmentNameEn { get; set; }

        [MaxLength(250)]
        public string? TreatmentNameAr { get; set; }

        [MaxLength(500)]
        public string? ImagePath { get; set; }

        [MaxLength(500)]
        public string? VideoUrl { get; set; }

        [Required]
        public string StoryEn { get; set; }

        [Required]
        public string StoryAr { get; set; }

        public int Rating { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int SortOrder { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}