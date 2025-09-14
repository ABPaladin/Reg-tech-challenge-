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
    public async Task<AutoCheckScoreDto> GetScore(int companyId)
    {
        var completedAtLeastOneTest = await context.AutomaticCheckAuditHeaders
            .Where(c => c.CompanyId == companyId)
            .Where(c => c.IsCompleted)
            .AnyAsync();

        if (!completedAtLeastOneTest)
            return new AutoCheckScoreDto
            {
                PassedChecks = 0,
                TotalChecks = 0
            };

        
        var latestCheckId = await context.AutomaticCheckAuditHeaders
            .Where(c => c.CompanyId == companyId)
            .MaxAsync(c => c.Id);

        var passedChecks = await context.AutomaticCheckAuditRows
            .Where(r => r.AutomaticCheckAuditHeaderId == latestCheckId)
            .Where(r => r.Passed)
            .CountAsync();

        var totalChecks = await context.AutomaticChecks.CountAsync();

        return new AutoCheckScoreDto
        {
            PassedChecks = passedChecks,
            TotalChecks = totalChecks
        };
    }

    public async Task<List<AutoCheckResponseDto>> GetOldAutoChecks(int companyId)
    {
        var autoChecks = await context.AutomaticCheckAuditHeaders
            .Where(a => a.CompanyId == companyId)
            .Include(a => a.AutomaticCheckAuditRows)
            .ThenInclude(r => r.AutomaticCheck)
            .ToListAsync();

        return mapper.Map<List<AutoCheckResponseDto>>(autoChecks);
    }

    public async Task<AutoCheckResponseDto> ExecuteNewAutoCheck(int companyId, string ipToCheck)
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
        autoCheck.AutomaticCheckAuditRows.Add(await tlsScanService.Scan(ipToCheck));
        autoCheck.AutomaticCheckAuditRows.Add(await cveScanService.Scan(ipToCheck));
        autoCheck.AutomaticCheckAuditRows.Add(await portScanService.Scan(ipToCheck));
        
        
        autoCheck.IsCompleted = true;
        await context.SaveChangesAsync();
        
        return mapper.Map<AutoCheckResponseDto>(autoCheck);
    }
}