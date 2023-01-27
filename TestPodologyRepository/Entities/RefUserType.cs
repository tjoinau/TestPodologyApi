using System;
using System.Collections.Generic;

namespace TestPodologyRepository.Entities;

public partial class RefUserType
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
