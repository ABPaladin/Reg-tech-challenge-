using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class AutomaticCheckAuditRow
{
    public int Id { get; set; }

    public int AutomaticCheckAuditHeaderId { get; set; }

    public int AutomaticCheckId { get; set; }

    public bool Passed { get; set; }

    public string? Comment { get; set; }

    public virtual AutomaticCheck AutomaticCheck { get; set; } = null!;

    public virtual AutomaticCheckAuditHeader AutomaticCheckAuditHeader { get; set; } = null!;
}
