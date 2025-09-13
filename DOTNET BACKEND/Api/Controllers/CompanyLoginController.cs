using Application.Interfaces;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyLoginController(ICompanyLoginService service) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<CompanyRegisterResponseDTO>> Register(CompanyRegisterRequestDTO requestDto)
    {
        return Ok(await service.Register(requestDto));
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<CompanyLoginResponseDto>> Login(CompanyLoginRequestDto requestDto)
    {
        return Ok(await service.Login(requestDto));
    }
}