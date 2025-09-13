using Application.Interfaces;
using Domain.DTO;

namespace Application.Services;

public class IncidentService : IIncidentService
{
    public Task<List<IncidentResponseDTO>> GetCompanyIncidents(int companyId)
    {
        throw new NotImplementedException();
    }

    public Task<IncidentResponseDTO> CreateIncident(CreateIncidentRequestDTO requestDto)
    {
        throw new NotImplementedException();
    }

    public Task<IncidentResponseDTO> UpdateIncident(UpdateIncidentRequestDTO requestDto)
    {
        throw new NotImplementedException();
    }

    public Task<IncidentResponseDTO> CloseIncident(CloseIncidentRequestDTO requestDto)
    {
        throw new NotImplementedException();
    }
}