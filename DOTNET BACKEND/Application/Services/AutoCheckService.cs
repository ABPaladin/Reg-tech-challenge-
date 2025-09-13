using Application.Interfaces;
using AutoMapper;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;

namespace Application.Services;

public class AutoCheckService(PgContext context, IMapper mapper) : IAutoCheckService
{
    public async Task<List<AutoCheckResponseDTO>> GetOldAutoChecks(int companyId)
    {
        var autochecks = await context.AutomaticCheckAuditHeaders
            .Where(a => a.CompanyId == companyId)
            .Include(a => a.AutomaticCheckAuditRows)
            .ThenInclude(r => r.AutomaticCheck)
            .ToListAsync();

        return mapper.Map<List<AutoCheckResponseDTO>>(autochecks);
    }

    public async Task ExecuteNewAutoCheck(int companyId, string ipToCheck)
    {
        var autocheck = new AutomaticCheckAuditHeader
        {
            CompanyId = companyId,
            IpAddress = ipToCheck,
            IsCompleted = true,
            AutomaticCheckAuditRows = await context.AutomaticChecks
                .Select(c => new AutomaticCheckAuditRow
                {
                    AutomaticCheck = c,
                    Comment = "yay",
                    Passed = true
                })
                .ToListAsync()
        };
        
        context.AutomaticCheckAuditHeaders.Add(autocheck);
        await context.SaveChangesAsync();
    }
}