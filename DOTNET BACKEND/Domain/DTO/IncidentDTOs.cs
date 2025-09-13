namespace Domain.DTO;

public class CreateIncidentRequestDTO
{
    public int CompanyId { get; set; }
    public string? FirstResponse { get; set; }
    public bool? IsCritical { get; set; }
    public bool? IsInitiallyAverted { get; set; }
    public int? RepeatIncidentId { get; set; }
}

public class UpdateIncidentRequestDTO
{
    public int IncidentId { get; set; }
    public string? Text { get; set; }
}

public class CloseIncidentRequestDTO
{
    public int IncidentId { get; set; }
    public string? Text { get; set; }
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
    public string Status { get; set; }
}