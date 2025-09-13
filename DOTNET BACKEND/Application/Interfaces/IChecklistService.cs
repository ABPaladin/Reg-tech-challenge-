using Domain.DTO;

namespace Application.Interfaces;

public interface IChecklistService
{
    public Task<List<ChecklistResponseDTO>> GetAnsweredChecklists(int companyId);
    public Task<List<ChecklistQuestionDTO>> GetQuestions();
    public Task<ChecklistResponseDTO> AnswerChecklist(ChecklistRequestDTO requestDto);
}