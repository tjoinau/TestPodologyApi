using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Device
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool Deleted { get; set; }

    public int ShopId { get; set; }

    public string? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Pointing> Pointings { get; } = new List<Pointing>();

    public virtual Shop Shop { get; set; } = null!;
}
