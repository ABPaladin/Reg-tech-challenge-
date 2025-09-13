using Domain.DTO;

namespace Application.Interfaces;

public interface IAutoCheckService
{
    public Task<List<AutoCheckResponseDTO>> GetOldAutoChecks(int companyId);
    public Task<AutoCheckResponseDTO> ExecuteNewAutoCheck(int companyId, string ipToCheck);
}