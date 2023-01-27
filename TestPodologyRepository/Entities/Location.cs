using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<Consultation> Consultations { get; } = new List<Consultation>();

    public virtual ICollection<LocationHealthCareProvider> LocationHealthCareProviders { get; } = new List<LocationHealthCareProvider>();
}
