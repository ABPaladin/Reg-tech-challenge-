using Application.Interfaces;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AutoCheckController(IAutoCheckService service) : ControllerBase
{
    //TODO: endpoint for score
    [HttpGet]
    public async Task<ActionResult<List<AutoCheckResponseDTO>>> GetOldAutoChecks(int companyId)
    {
        return Ok(await service.GetOldAutoChecks(companyId));
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteNewAutoCheck(int companyId, string ipToCheck)
    {
        await service.ExecuteNewAutoCheck(companyId, ipToCheck);
        return Ok();
    }
}