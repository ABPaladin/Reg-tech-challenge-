namespace Domain.DTO;

public class AutoCheckResponseDTO
{
    public int Id { get; set; }
    public string IpAddress { get; set; } = null!;
    public bool IsCompleted { get; set; }
    public DateTime Datetime { get; set; }
    public List<AutoCheckResponseRowDTO> Rows { get; set; } = [];
}

public class AutoCheckResponseRowDTO
{
    public int CheckOrder { get; set; }
    public string CheckName { get; set; } = null!;
    public bool? Passed { get; set; }
    public string? Comment { get; set; }
}