using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class AutomaticCheck
{
    public int Id { get; set; }

    public int CheckOrder { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AutomaticCheckAuditRow> AutomaticCheckAuditRows { get; set; } = new List<AutomaticCheckAuditRow>();
}
