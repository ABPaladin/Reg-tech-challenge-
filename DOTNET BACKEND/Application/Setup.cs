using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Application;

public static class Setup
{
    public static void SetupApplication(this IServiceCollection services)
    {
        services.AddScoped<IAutoCheckService, AutoCheckService>();
        services.AddScoped<IChecklistService, ChecklistService>();
        services.AddScoped<ICompanyLoginService, CompanyLoginService>();
        services.AddScoped<IIncidentService, IncidentService>();

        services.AddAutoMapper(x => x.AddProfile<MappingProfile>());
    }
}