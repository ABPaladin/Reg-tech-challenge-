using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ResponsiblePhone { get; set; }

    public string? ResponsibleEmail { get; set; }

    public virtual ICollection<AutomaticCheckAuditHeader> AutomaticCheckAuditHeaders { get; set; } = new List<AutomaticCheckAuditHeader>();

    public virtual ICollection<Checklist> Checklists { get; set; } = new List<Checklist>();

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}
