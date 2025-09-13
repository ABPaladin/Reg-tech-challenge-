using Application.Interfaces;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IncidentController(IIncidentService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<IncidentResponseDTO>>> GetCompanyIncidents(int companyId)
    {
        return Ok(await service.GetCompanyIncidents(companyId));
    }

    [HttpPost("first")]
    public async Task<ActionResult<IncidentResponseDTO>> CreateIncident(CreateIncidentRequestDTO requestDto)
    {
        return Ok(await service.CreateIncident(requestDto));
    }
    
    [HttpPost("second-DO-NOT-USE")]
    public async Task<ActionResult<IncidentResponseDTO>> UpdateIncident(UpdateIncidentRequestDTO requestDto)
    {
        return Ok(await service.UpdateIncident(requestDto));
    }

    [HttpPost("third")]
    public async Task<ActionResult<IncidentResponseDTO>> CloseIncident(CloseIncidentRequestDTO requestDto)
    {
        return Ok(await service.CloseIncident(requestDto));
    }
}