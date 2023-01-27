using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string RegisterNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RefUserTypeId { get; set; }

    public virtual RefUserType RefUserType { get; set; } = null!;
}
