using Application.Interfaces;
using AutoMapper;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using PenTest.Interfaces;
using Repository;
using Repository.Entities;

namespace Application.Services;

public class AutoCheckService(
    PgContext context, 
    IMapper mapper,
    IPortScanService portScanService,
    ICveScanService cveScanService,
    ITlsScanService tlsScanService) : IAutoCheckService
{
    public async Task<List<AutoCheckResponseDTO>> GetOldAutoChecks(int companyId)
    {
        var autoChecks = await context.AutomaticCheckAuditHeaders
            .Where(a => a.CompanyId == companyId)
            .Include(a => a.AutomaticCheckAuditRows)
            .ThenInclude(r => r.AutomaticCheck)
            .ToListAsync();

        return mapper.Map<List<AutoCheckResponseDTO>>(autoChecks);
    }

    public async Task<AutoCheckResponseDTO> ExecuteNewAutoCheck(int companyId, string ipToCheck)
    {
        var autoCheck = new AutomaticCheckAuditHeader
        {
            CompanyId = companyId,
            IpAddress = ipToCheck,
            IsCompleted = false,

        };
        context.AutomaticCheckAuditHeaders.Add(autoCheck);
        await context.SaveChangesAsync();

        

        // await portScanService.Scan(ipToCheck);
        autoCheck.AutomaticCheckAuditRows.Add(await portScanService.Scan(ipToCheck));
        // autoCheck.AutomaticCheckAuditRows.Add(await tlsScanService.Scan(ipToCheck));
        autoCheck.AutomaticCheckAuditRows.Add(await cveScanService.Scan(ipToCheck));
        
        
        autoCheck.IsCompleted = true;
        await context.SaveChangesAsync();
        
        return mapper.Map<AutoCheckResponseDTO>(autoCheck);
    }
}