using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class AutomaticCheckAuditHeader
{
    public int Id { get; set; }

    public int CompanyIpId { get; set; }

    public DateTime Datetime { get; set; }

    public virtual ICollection<AutomaticCheckAuditRow> AutomaticCheckAuditRows { get; set; } = new List<AutomaticCheckAuditRow>();

    public virtual CompanyIp CompanyIp { get; set; } = null!;
}
