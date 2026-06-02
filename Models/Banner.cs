using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Banner
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string TitleEn { get; set; }

        [Required]
        [MaxLength(200)]
        public string TitleAr { get; set; }

        [MaxLength(500)]
        public string? SubTitleEn { get; set; }

        [MaxLength(500)]
        public string? SubTitleAr { get; set; }

        [MaxLength(300)]
        public string? ButtonTextEn { get; set; }

        [MaxLength(300)]
        public string? ButtonTextAr { get; set; }

        [MaxLength(500)]
        public string? ButtonUrl { get; set; }

        [Required]
        [MaxLength(500)]
        public string ImagePath { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}