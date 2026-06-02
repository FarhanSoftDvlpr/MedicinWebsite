namespace MEDICINE.WEB.Models
{
    public class DoctorTreatment
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public int TreatmentId { get; set; }

        public Treatment Treatment { get; set; }
    }
}