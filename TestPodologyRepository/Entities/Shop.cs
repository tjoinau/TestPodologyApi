using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Shop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool Deleted { get; set; }

    public string Color { get; set; } = null!;

    public string CompanyId { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Device> Devices { get; } = new List<Device>();

    public virtual ICollection<Hour> Hours { get; } = new List<Hour>();

    public virtual ICollection<Pointing> Pointings { get; } = new List<Pointing>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
