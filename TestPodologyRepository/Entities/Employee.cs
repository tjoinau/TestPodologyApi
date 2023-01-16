using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int TypeEmployeeId { get; set; }

    public bool Deleted { get; set; }

    public string NationalNumber { get; set; } = null!;

    public DateTime EntryDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string CompanyId { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Hour> Hours { get; } = new List<Hour>();

    public virtual ICollection<Pointing> Pointings { get; } = new List<Pointing>();

    public virtual TypeEmployee TypeEmployee { get; set; } = null!;

    public virtual ICollection<Shop> Shops { get; } = new List<Shop>();
}
