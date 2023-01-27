namespace TestPodologyModel.DTOs
{
    public class ConsultationDto
    {
        public int Id { get; set; }

        public int StatusId { get; set; }

        public PatientDto Patient { get; set; }

        //public string PatientId { get; set; }

        public string HealthCareProviderId { get; set; }

        public int LocationId { get; set; }

        public DateTime StartConsultation { get; set; }

        public DateTime EndConsultation { get; set; }

        public string? PatientInput { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
