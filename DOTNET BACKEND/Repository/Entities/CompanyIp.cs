using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class CompanyIp
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<AutomaticCheckAuditHeader> AutomaticCheckAuditHeaders { get; set; } = new List<AutomaticCheckAuditHeader>();

    public virtual Company Company { get; set; } = null!;
}
