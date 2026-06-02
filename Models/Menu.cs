using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Menu
    {
        public int Id { get; set; }

        public int? ParentMenuId { get; set; }

        [Required]
        [MaxLength(200)]
        public string TitleEn { get; set; }

        [Required]
        [MaxLength(200)]
        public string TitleAr { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }

        public int SortOrder { get; set; }

        public bool OpenInNewTab { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Menu? ParentMenu { get; set; }

        public ICollection<Menu> ChildMenus { get; set; } = new List<Menu>();
    }
}