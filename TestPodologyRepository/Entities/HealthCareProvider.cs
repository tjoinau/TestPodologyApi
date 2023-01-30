using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class HealthCareProvider
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Consultation> Consultations { get; } = new List<Consultation>();

    public virtual ICollection<Hcpconfiguration> Hcpconfigurations { get; } = new List<Hcpconfiguration>();

    public virtual ICollection<LocationHealthCareProvider> LocationHealthCareProviders { get; } = new List<LocationHealthCareProvider>();
}
