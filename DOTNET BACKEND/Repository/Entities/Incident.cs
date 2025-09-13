using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Incident
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string FirstResponse { get; set; } = null!;

    public DateTime FirstResponseTimestamp { get; set; }

    public string? SecondResponse { get; set; }

    public DateTime? SecondResponseTimestamp { get; set; }

    public string? ThirdResponse { get; set; }

    public DateTime? ThirdResponseTimestamp { get; set; }

    public bool IsCritical { get; set; }

    public bool IsInitiallyAverted { get; set; }

    public int? RepeatIncidentId { get; set; }

    public int Status { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Incident> InverseRepeatIncident { get; set; } = new List<Incident>();

    public virtual Incident? RepeatIncident { get; set; }

    public virtual IncidentStatus StatusNavigation { get; set; } = null!;
}
