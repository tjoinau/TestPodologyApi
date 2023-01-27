using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class LocationHealthCareProvider
{
    public int Id { get; set; }

    public string HealthCareProviderId { get; set; } = null!;

    public int LocationId { get; set; }

    public virtual HealthCareProvider HealthCareProvider { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
