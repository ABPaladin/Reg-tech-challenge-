namespace Domain.DTO;

public class CompanyLoginRequestDto
{
    public string Password { get; set; }
}

public class CompanyLoginResponseDto
{
    public int CompanyId { get; set; }
}