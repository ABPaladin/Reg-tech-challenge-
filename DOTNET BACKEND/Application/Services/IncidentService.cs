using Application.Interfaces;
using AutoMapper;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;

namespace Application.Services;

public class IncidentService(PgContext context, IMapper mapper) : IIncidentService
{
    private readonly string FirstStatusName = "INITIAL";
    private readonly string SecondStatusName = "UPDATED";
    private readonly string ThirdStatusName = "FINAL";
    
    public async Task<List<IncidentResponseDTO>> GetCompanyIncidents(int companyId)
    {
        return await mapper.ProjectTo<IncidentResponseDTO>(
            context.Incidents
                .Where(i => i.CompanyId == companyId)
                .Include(i => i.Status)
            ).ToListAsync();
    }

    public async Task<IncidentResponseDTO> CreateIncident(CreateIncidentRequestDTO requestDto)
    {
        var incident = mapper.Map<Incident>(requestDto);
        var status = await context.IncidentStatuses.Where(s => s.Name == FirstStatusName).FirstAsync();
        incident.Status = status;
        
        context.Incidents.Add(incident);
        await context.SaveChangesAsync();
        
        return mapper.Map<IncidentResponseDTO>(incident);
    }

    public async Task<IncidentResponseDTO> UpdateIncident(UpdateIncidentRequestDTO requestDto)
    {
        var incident = await context.Incidents.FindAsync(requestDto.IncidentId);
        var status = await context.IncidentStatuses.Where(s => s.Name == SecondStatusName).FirstAsync();
        incident.Status = status;

        incident.SecondResponse = requestDto.Text;
        incident.SecondResponseTimestamp = DateTime.UtcNow;
        await context.SaveChangesAsync();
        
        return mapper.Map<IncidentResponseDTO>(incident);
    }

    public async Task<IncidentResponseDTO> CloseIncident(CloseIncidentRequestDTO requestDto)
    {
        var incident = await context.Incidents.FindAsync(requestDto.IncidentId);
        var status = await context.IncidentStatuses.Where(s => s.Name == ThirdStatusName).FirstAsync();
        incident.Status = status;

        incident.ThirdResponse = requestDto.Text;
        incident.ThirdResponseTimestamp = DateTime.UtcNow;
        await context.SaveChangesAsync();
        
        return mapper.Map<IncidentResponseDTO>(incident);
    }
}