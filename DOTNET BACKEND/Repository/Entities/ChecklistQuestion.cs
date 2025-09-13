using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class ChecklistQuestion
{
    public int Id { get; set; }

    public int QuestionOrder { get; set; }

    public string QuestionText { get; set; } = null!;

    public string Recommendations { get; set; } = null!;

    public virtual ICollection<ChecklistAnswerRow> ChecklistAnswerRows { get; set; } = new List<ChecklistAnswerRow>();
}
