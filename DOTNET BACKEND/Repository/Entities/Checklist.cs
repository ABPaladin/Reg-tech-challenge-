using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class Checklist
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public DateTime Datetime { get; set; }

    public virtual ICollection<ChecklistAnswerRow> ChecklistAnswerRows { get; set; } = new List<ChecklistAnswerRow>();

    public virtual Company Company { get; set; } = null!;
}
