using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class PatientConfiguration
{
    public int Id { get; set; }

    public string PatientId { get; set; } = null!;

    public string Configuration { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
