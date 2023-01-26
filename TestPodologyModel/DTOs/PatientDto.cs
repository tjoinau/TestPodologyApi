namespace TestPodologyModel.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}
