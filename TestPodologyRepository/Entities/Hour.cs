using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Hour
{
    public int EmployeeId { get; set; }

    public int ShopId { get; set; }

    public int Year { get; set; }

    public int Week { get; set; }

    public string Hours { get; set; } = null!;

    public string? TotalWorkTime { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
