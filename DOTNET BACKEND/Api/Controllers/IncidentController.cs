using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IncidentController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCompanyIncidents(int companyId)
    {
        return Ok();
    }
}