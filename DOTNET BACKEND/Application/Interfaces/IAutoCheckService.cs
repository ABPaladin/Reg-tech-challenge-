using Domain.DTO;

namespace Application.Interfaces;

public interface IAutoCheckService
{
    public Task<AutoCheckScoreDto> GetScore(int companyId);
    public Task<List<AutoCheckResponseDto>> GetOldAutoChecks(int companyId);
    public Task<AutoCheckResponseDto> ExecuteNewAutoCheck(int companyId, string ipToCheck);
}