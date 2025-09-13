namespace Domain.DTO;

public class CompanyRegisterRequestDTO
{
    public string? Name { get; set; } = null!;
    public string? Password { get; set; } = null!;
    public string? ResponsiblePhone { get; set; }
    public string? ResponsibleEmail { get; set; }
}

public class CompanyRegisterResponseDTO
{
    public int Id { get; set; }
}
