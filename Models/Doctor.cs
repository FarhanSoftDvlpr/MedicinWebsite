using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string FullNameEn { get; set; }

        [Required]
        [MaxLength(250)]
        public string FullNameAr { get; set; }

        [MaxLength(250)]
        public string? DesignationEn { get; set; }

        [MaxLength(250)]
        public string? DesignationAr { get; set; }

        [MaxLength(250)]
        public string? QualificationEn { get; set; }

        [MaxLength(250)]
        public string? QualificationAr { get; set; }

        public int ExperienceYears { get; set; }

        [MaxLength(250)]
        public string? Languages { get; set; }

        [MaxLength(500)]
        public string? ShortDescriptionEn { get; set; }

        [MaxLength(500)]
        public string? ShortDescriptionAr { get; set; }

        public string? DescriptionEn { get; set; }

        public string? DescriptionAr { get; set; }

        [MaxLength(500)]
        public string? ImagePath { get; set; }

        [MaxLength(250)]
        public string? Slug { get; set; }

        [MaxLength(250)]
        public string? MetaTitleEn { get; set; }

        [MaxLength(250)]
        public string? MetaTitleAr { get; set; }

        [MaxLength(500)]
        public string? MetaDescriptionEn { get; set; }

        [MaxLength(500)]
        public string? MetaDescriptionAr { get; set; }

        public int SortOrder { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? HospitalId { get; set; }

        public Hospital? Hospital { get; set; }

        public int? CountryId { get; set; }

        public Country? Country { get; set; }

        public int? StateId { get; set; }

        public State? State { get; set; }

        public int? CityId { get; set; }

        public City? City { get; set; }

        public ICollection<DoctorTreatment> DoctorTreatments { get; set; }
            = new List<DoctorTreatment>();
    }
}