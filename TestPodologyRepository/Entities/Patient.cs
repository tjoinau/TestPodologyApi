using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Patient
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? BirthDay { get; set; }

    public virtual ICollection<Consultation> Consultations { get; } = new List<Consultation>();

    public virtual ICollection<PatientConfiguration> PatientConfigurations { get; } = new List<PatientConfiguration>();
}
