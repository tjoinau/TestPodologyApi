namespace TestPodologyModel.Search
{
    public class ConsultationSearch
    {
        public string? HealthCheckProviderId { get; set; }
        public string? PatientId { get; set; }
        public DateTime? StartDateBefore { get; set; }
        public DateTime? StartDateAfter { get; set; }
        public DateTime? EndDateBefore { get; set; }
        public DateTime? EndDateAfter { get; set; }
        public int? Location { get; set; }
        public int? Id { get; set; }
    }
}
