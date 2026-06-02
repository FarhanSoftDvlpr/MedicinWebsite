using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class FooterSetting
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string CompanyNameEn { get; set; }

        [Required]
        [MaxLength(200)]
        public string CompanyNameAr { get; set; }

        public string? AboutTextEn { get; set; }

        public string? AboutTextAr { get; set; }

        [MaxLength(500)]
        public string? AddressEn { get; set; }

        [MaxLength(500)]
        public string? AddressAr { get; set; }

        [MaxLength(50)]
        public string? PhoneNumber { get; set; }

        [MaxLength(50)]
        public string? WhatsAppNumber { get; set; }

        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(500)]
        public string? FacebookUrl { get; set; }

        [MaxLength(500)]
        public string? InstagramUrl { get; set; }

        [MaxLength(500)]
        public string? YouTubeUrl { get; set; }

        [MaxLength(500)]
        public string? LinkedInUrl { get; set; }

        [MaxLength(500)]
        public string? TwitterUrl { get; set; }

        [MaxLength(1000)]
        public string? GoogleMapUrl { get; set; }

        [MaxLength(300)]
        public string? CopyrightTextEn { get; set; }

        [MaxLength(300)]
        public string? CopyrightTextAr { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}