namespace Domain.DTO;

public class ChecklistRequestDTO
{
    public int CompanyId { get; set; }
    public Dictionary<int, bool>? Answers { get; set; }
}

public class ChecklistResponseDTO
{
    public int Id { get; set; }
    public DateTime Datetime { get; set; }
    public List<ChecklistAnswerDTO> ChecklistAnswerRows { get; set; } = null!;
}

public class ChecklistAnswerDTO
{
    public int QuestionOrder { get; set; }
    public string QuestionText { get; set; } = null!;
    public bool AnsweredCorrectly { get; set; }
    public string? Recommendations { get; set; } = null!;
}

public class ChecklistQuestionDTO
{
    public int Id { get; set; }
    public int QuestionOrder { get; set; }
    public string QuestionText { get; set; } = null!;
}