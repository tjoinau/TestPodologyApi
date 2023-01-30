using TestPodologyModel.Models;

namespace TestPodologyModel.DTOs
{
    public class HCPConfigurationDto
    {
        public int Id { get; set; }
        public string HCPId { get; set; }
        public HCPConfigFormModel Config { get; set; }
    }
}
