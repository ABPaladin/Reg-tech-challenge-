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
        return Ok(new List<IncidentResponseDTO>());
    }

    [HttpPost("first")]
    public async Task<ActionResult<IncidentResponseDTO>> CreateIncident(CreateIncidentRequestDTO requestDto)
    {
        return Ok(new IncidentResponseDTO());
    }
    
    [HttpPost("second")]
    public async Task<ActionResult<IncidentResponseDTO>> UpdateIncident(UpdateIncidentRequestDTO requestDto)
    {
        return Ok(new IncidentResponseDTO());
    }

    [HttpPost("third")]
    public async Task<ActionResult<IncidentResponseDTO>> CloseIncident(CloseIncidentRequestDTO requestDto)
    {
        return Ok(new IncidentResponseDTO());
    }
}