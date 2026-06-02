using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public int? BlogCategoryId { get; set; }

        [Required]
        [MaxLength(250)]
        public string TitleEn { get; set; }

        [Required]
        [MaxLength(250)]
        public string TitleAr { get; set; }

        [Required]
        [MaxLength(300)]
        public string Slug { get; set; }

        [MaxLength(500)]
        public string? ShortDescriptionEn { get; set; }

        [MaxLength(500)]
        public string? ShortDescriptionAr { get; set; }

        public string? DescriptionEn { get; set; }

        public string? DescriptionAr { get; set; }

        [MaxLength(500)]
        public string? ImagePath { get; set; }

        [MaxLength(250)]
        public string? MetaTitleEn { get; set; }

        [MaxLength(250)]
        public string? MetaTitleAr { get; set; }

        [MaxLength(500)]
        public string? MetaDescriptionEn { get; set; }

        [MaxLength(500)]
        public string? MetaDescriptionAr { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime PublishedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public BlogCategory? BlogCategory { get; set; }
    }
}