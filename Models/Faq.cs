using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Faq
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string QuestionEn { get; set; }

        [Required]
        [MaxLength(500)]
        public string QuestionAr { get; set; }

        [Required]
        public string AnswerEn { get; set; }

        [Required]
        public string AnswerAr { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}