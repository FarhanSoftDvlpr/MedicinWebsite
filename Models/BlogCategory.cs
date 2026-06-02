using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class BlogCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string NameEn { get; set; }

        [Required]
        [MaxLength(200)]
        public string NameAr { get; set; }

        [Required]
        [MaxLength(250)]
        public string Slug { get; set; }

        [MaxLength(500)]
        public string? DescriptionEn { get; set; }

        [MaxLength(500)]
        public string? DescriptionAr { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    }
}