using System.Text.Json;
using Application.Interfaces;
using AutoMapper;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;

namespace Application.Services;

public class CompanyLoginService(PgContext context, IMapper mapper) : ICompanyLoginService
{
    public async Task<CompanyRegisterResponseDTO> Register(CompanyRegisterRequestDTO requestDto)
    {
        var company = mapper.Map<Company>(requestDto);
        
        Console.WriteLine(JsonSerializer.Serialize(company));
        
        context.Companies.Add(company);
        await context.SaveChangesAsync();
        
        return mapper.Map<CompanyRegisterResponseDTO>(company);
    }

    public async Task<CompanyLoginResponseDto> Login(CompanyLoginRequestDto requestDto)
    {
        var company = await context.Companies
            .Where(c => c.Password == requestDto.Password)
            .FirstAsync();
        
        return  mapper.Map<CompanyLoginResponseDto>(company);
    }
}