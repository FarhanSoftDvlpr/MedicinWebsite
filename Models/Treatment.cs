using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Treatment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string NameEn { get; set; }

        [Required]
        [MaxLength(200)]
        public string NameAr { get; set; }

        [MaxLength(500)]
        public string? ShortDescriptionEn { get; set; }

        [MaxLength(500)]
        public string? ShortDescriptionAr { get; set; }

        public string? DescriptionEn { get; set; }

        public string? DescriptionAr { get; set; }

        [MaxLength(250)]
        public string? Slug { get; set; }

        [MaxLength(500)]
        public string? ImagePath { get; set; }

        [MaxLength(500)]
        public string? IconClass { get; set; }

        [MaxLength(250)]
        public string? MetaTitleEn { get; set; }

        [MaxLength(250)]
        public string? MetaTitleAr { get; set; }

        [MaxLength(500)]
        public string? MetaDescriptionEn { get; set; }

        [MaxLength(500)]
        public string? MetaDescriptionAr { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}