using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyIpController : ControllerBase
{
    [HttpGet("{companyId:int}")]
    public async Task<ActionResult<List<string>>> GetCompanyIps(int companyId)
    {
        return Ok(new List<string>
        {
            "https://simpals.com",
            "https://999.md",
            "https://sporter.md",
        });
    }
    
    /// <summary>
    /// Overwrites current company ips with the given ones
    /// </summary>
    [HttpPost("{companyId:int}")]
    public async Task<ActionResult<List<string>>> SetCompanyIps(int companyId, List<string> ips)
    {
        return Ok(ips);
    }
}