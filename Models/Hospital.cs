using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Hospital
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameEn { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameAr { get; set; }

        [MaxLength(500)]
        public string? ShortDescriptionEn { get; set; }

        [MaxLength(500)]
        public string? ShortDescriptionAr { get; set; }

        public string? DescriptionEn { get; set; }

        public string? DescriptionAr { get; set; }

        // Old text fields kept for existing database/data compatibility
        [MaxLength(150)]
        public string? Country { get; set; }

        [MaxLength(150)]
        public string? City { get; set; }

        public int? CountryId { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public Country? CountryMaster { get; set; }

        public State? StateMaster { get; set; }

        public City? CityMaster { get; set; }

        [MaxLength(500)]
        public string? AddressEn { get; set; }

        [MaxLength(500)]
        public string? AddressAr { get; set; }

        [MaxLength(500)]
        public string? LogoPath { get; set; }

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
    }
}