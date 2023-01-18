using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class HealthCareProvider
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Consultation> Consultations { get; } = new List<Consultation>();
}
