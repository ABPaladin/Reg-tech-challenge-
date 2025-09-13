using Domain.DTO;

namespace Application.Interfaces;

public interface IIncidentService
{
    public Task<List<IncidentResponseDTO>> GetCompanyIncidents(int companyId);
    public Task<IncidentResponseDTO> CreateIncident(CreateIncidentRequestDTO requestDto);
    public Task<IncidentResponseDTO> UpdateIncident(UpdateIncidentRequestDTO requestDto);
    public Task<IncidentResponseDTO> CloseIncident(CloseIncidentRequestDTO requestDto);
}