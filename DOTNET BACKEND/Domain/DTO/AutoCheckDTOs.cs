namespace Domain.DTO;

public class AutoCheckResponseDto
{
    public int Id { get; set; }
    public string IpAddress { get; set; } = null!;
    public bool IsCompleted { get; set; }
    public DateTime Datetime { get; set; }
    public List<AutoCheckResponseRowDto> AutomaticCheckAuditRows { get; set; } = [];
}

public class AutoCheckResponseRowDto
{
    public int CheckOrder { get; set; }
    public string CheckName { get; set; } = null!;
    public bool? Passed { get; set; }
    public string? Comment { get; set; }
}

public class AutoCheckScoreDto
{
    public int PassedChecks { get; set; }
    public int TotalChecks { get; set; }
}