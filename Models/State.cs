using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class State
    {
        public int Id { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        [MaxLength(150)]
        public string NameEn { get; set; }

        [Required]
        [MaxLength(150)]
        public string NameAr { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}