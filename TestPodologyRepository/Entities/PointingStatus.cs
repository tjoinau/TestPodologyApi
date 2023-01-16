using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class PointingStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public string DisplayedStatus { get; set; } = null!;

    public virtual ICollection<Pointing> Pointings { get; } = new List<Pointing>();
}
