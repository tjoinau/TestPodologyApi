using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Company
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<AspNetUser> AspNetUsers { get; } = new List<AspNetUser>();

    public virtual ICollection<Device> Devices { get; } = new List<Device>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<Pointing> Pointings { get; } = new List<Pointing>();

    public virtual ICollection<Shop> Shops { get; } = new List<Shop>();
}
