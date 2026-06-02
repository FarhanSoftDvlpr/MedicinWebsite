using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string NameEn { get; set; }

        [Required]
        [MaxLength(150)]
        public string NameAr { get; set; }

        [MaxLength(10)]
        public string? CountryCode { get; set; }

        [MaxLength(10)]
        public string? PhoneCode { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<State> States { get; set; } = new List<State>();
    }
}