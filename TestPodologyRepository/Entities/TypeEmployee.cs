using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class TypeEmployee
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
