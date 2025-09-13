namespace Domain.DTO;

public class IncidentRequestDTO
{
    
}

public class IncidentResponseDTO
{
    public int Id { get; set; }
    public string FirstResponse { get; set; } = null!;
    public DateTime FirstResponseTimestamp { get; set; }
    public string? SecondResponse { get; set; }
    public DateTime? SecondResponseTimestamp { get; set; }
    public string? ThirdResponse { get; set; }
    public DateTime? ThirdResponseTimestamp { get; set; }
    public bool IsCritical { get; set; }
    public bool IsInitiallyAverted { get; set; }
    public int? RepeatIncidentId { get; set; }
    public int Status { get; set; }
}