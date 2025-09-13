using Application.Interfaces;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ChecklistController(IChecklistService service) : ControllerBase
{
    [HttpGet("{companyId:int}")]
    public async Task<ActionResult<List<ChecklistResponseDTO>>> GetAnsweredChecklists(int companyId)
    {
        return Ok(await service.GetAnsweredChecklists(companyId));
    }

    [HttpGet("questions")]
    public async Task<ActionResult<List<ChecklistQuestionDTO>>> GetQuestions()
    {
        return Ok(await service.GetQuestions());
    }

    [HttpPost]
    public async Task<ActionResult<ChecklistResponseDTO>> AnswerChecklist(ChecklistRequestDTO requestDto)
    {
        return Ok(await service.AnswerChecklist(requestDto));
    }
}