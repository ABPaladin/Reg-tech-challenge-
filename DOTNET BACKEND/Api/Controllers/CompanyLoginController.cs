using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyLoginController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CompanyLoginResponseDto>> Login(CompanyLoginRequestDto requestDto)
    {
        return Ok(new CompanyLoginResponseDto
        {
            CompanyId = 999
        });
    }
}