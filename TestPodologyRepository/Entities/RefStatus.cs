using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class RefStatus
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Consultation> Consultations { get; } = new List<Consultation>();
}
