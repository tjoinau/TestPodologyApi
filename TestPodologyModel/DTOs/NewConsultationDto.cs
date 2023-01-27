namespace TestPodologyModel.DTOs
{
    public class NewConsultationDto
    {
        public string PatientId { get; set; }

        public string HealthCareProviderId { get; set; }

        public int LocationId { get; set; }

        public DateTime StartConsultation { get; set; }

        public string? PatientInput { get; set; }

    }
}
