namespace TestPodologyModel.DTOs
{
    public class LocationDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int HealthCareProviderId { get; set; }
    }
}
