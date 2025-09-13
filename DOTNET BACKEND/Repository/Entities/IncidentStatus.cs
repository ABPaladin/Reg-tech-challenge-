using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class IncidentStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int StatusOrder { get; set; }

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}
