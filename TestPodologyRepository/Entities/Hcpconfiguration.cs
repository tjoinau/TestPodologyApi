using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Hcpconfiguration
{
    public int Id { get; set; }

    public string HcpId { get; set; } = null!;

    public string Config { get; set; } = null!;

    public virtual HealthCareProvider Hcp { get; set; } = null!;
}
