using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Pointing
{
    public int Id { get; set; }

    public int ShopId { get; set; }

    public int EmployeeId { get; set; }

    public int StatusId { get; set; }

    public DateTime DateTimePointing { get; set; }

    public string DeviceId { get; set; } = null!;

    public string DatePointing { get; set; } = null!;

    public string? Comment { get; set; }

    public bool CommentIsDone { get; set; }

    public string CompanyId { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual Device Device { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;

    public virtual PointingStatus Status { get; set; } = null!;
}
