using System.ComponentModel.DataAnnotations;

namespace MEDICINE.WEB.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string PatientName { get; set; }

        [MaxLength(250)]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? MobileNumber { get; set; }

        public int? CountryId { get; set; }

        public Country? Country { get; set; }

        public int? StateId { get; set; }

        public State? State { get; set; }

        public int? CityId { get; set; }

        public City? City { get; set; }

        public int? TreatmentId { get; set; }

        public Treatment? Treatment { get; set; }

        public int? HospitalId { get; set; }

        public Hospital? Hospital { get; set; }

        public int? DoctorId { get; set; }

        public Doctor? Doctor { get; set; }

        [MaxLength(100)]
        public string InquirySource { get; set; }

        [MaxLength(100)]
        public string InquiryStatus { get; set; }

        public string? Message { get; set; }

        public string? AdminNotes { get; set; }

        public int? AssignedAdminUserId { get; set; }

        public Admin.AdminUser? AssignedAdminUser { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}