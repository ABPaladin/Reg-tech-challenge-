using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class AutomaticCheckAuditHeader
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string IpAddress { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime Datetime { get; set; }

    public virtual ICollection<AutomaticCheckAuditRow> AutomaticCheckAuditRows { get; set; } = new List<AutomaticCheckAuditRow>();

    public virtual Company Company { get; set; } = null!;
}
