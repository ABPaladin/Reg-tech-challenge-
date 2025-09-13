using System;
using System.Collections.Generic;

namespace Repository.Entities;

public partial class ChecklistAnswerRow
{
    public int Id { get; set; }

    public int ChecklistId { get; set; }

    public int QuestionId { get; set; }

    public bool AnsweredCorrectly { get; set; }

    public virtual Checklist Checklist { get; set; } = null!;

    public virtual ChecklistQuestion Question { get; set; } = null!;
}
