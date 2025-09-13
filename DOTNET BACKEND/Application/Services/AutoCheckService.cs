using Application.Interfaces;
using Domain.DTO;

namespace Application.Services;

public class AutoCheckService : IAutoCheckService
{
    public Task<List<AutoCheckResponseDTO>> GetOldAutoChecks(int companyId)
    {
        throw new NotImplementedException();
    }

    public Task ExecuteNewAutoCheck(int companyId, string ipToCheck)
    {
        throw new NotImplementedException();
    }
}