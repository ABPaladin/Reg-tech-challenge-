using Domain.DTO;

namespace Application.Interfaces;

public interface ICompanyLoginService
{
    public Task<CompanyRegisterResponseDTO> Register(CompanyRegisterRequestDTO requestDto);
    public Task<CompanyLoginResponseDto> Login(CompanyLoginRequestDto requestDto);
}