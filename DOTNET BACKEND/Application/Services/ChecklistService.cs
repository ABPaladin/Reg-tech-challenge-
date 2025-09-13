using Application.Interfaces;
using AutoMapper;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;

namespace Application.Services;

public class ChecklistService(PgContext context, IMapper mapper) : IChecklistService
{
    public async Task<AutoCheckScoreDto> GetScore(int companyId)
    {
        var completedAtLeastOneTest = await context.Checklists
            .Where(c => c.CompanyId == companyId)
            .AnyAsync();

        if (!completedAtLeastOneTest)
            return new AutoCheckScoreDto
            {
                PassedChecks = 0,
                TotalChecks = 0
            };
        
        var latestChecklistId = await context.Checklists
            .Where(c => c.CompanyId == companyId)
            .MaxAsync(x => x.Id);

        var passedChecks = await context.ChecklistAnswerRows
            .Where(a => a.ChecklistId == latestChecklistId)
            .Where(x => x.AnsweredCorrectly)
            .CountAsync();

        var totalChecks = await context.ChecklistQuestions.CountAsync();

        return new AutoCheckScoreDto
        {
            PassedChecks = passedChecks,
            TotalChecks = totalChecks
        };
    }

    public async Task<List<ChecklistResponseDTO>> GetAnsweredChecklists(int companyId)
    {
        // var checklist = await mapper.ProjectTo<ChecklistResponseDTO>(context.Checklists
        //     .Where(c => c.CompanyId == companyId)).FirstAsync();
        //
        //
        // checklist.Answers = await context.ChecklistAnswerRows
        //     .Where(a => a.ChecklistId == checklist.Id)
        //     .Join(context.ChecklistQuestions, a => a.QuestionId, c => c.Id,
        //         (a, q) => new ChecklistAnswerDTO
        //         {
        //             QuestionOrder = q.QuestionOrder,
        //             QuestionText = q.QuestionText,
        //             AnsweredCorrectly = a.AnsweredCorrectly,
        //             Recommendations = a.AnsweredCorrectly? null :  q.Recommendations,
        //         })
        //     .ToListAsync();

        // var checklists = await context.Checklists
        //     .Where(c => c.CompanyId == companyId)
        //     .Include(c => c.ChecklistAnswerRows)
        //     .ThenInclude(a => a.Question)
        //     .ToListAsync();

        var result = await mapper.ProjectTo<ChecklistResponseDTO>(
            context.Checklists
                .Where(c => c.CompanyId == companyId)
                .Include(c => c.ChecklistAnswerRows)
                .ThenInclude(a => a.Question)).ToListAsync();

        return result;
    }

    public async Task<List<ChecklistQuestionDTO>> GetQuestions()
    {
        var questions = await context.ChecklistQuestions.ToListAsync();
        return mapper.Map<List<ChecklistQuestionDTO>>(questions);
        
        return await mapper.ProjectTo<ChecklistQuestionDTO>(context.ChecklistQuestions).ToListAsync();
    }

    public async Task<ChecklistResponseDTO> AnswerChecklist(ChecklistRequestDTO requestDto)
    {
        var checklist = new Checklist { CompanyId = requestDto.CompanyId };

        checklist.ChecklistAnswerRows = requestDto.Answers.Select((kvp) => new ChecklistAnswerRow
            {
                QuestionId = kvp.Key,
                AnsweredCorrectly = kvp.Value
            }
        ).ToList();
        
        context.Checklists.Add(checklist);
        await context.SaveChangesAsync();
        
        
        var result = await mapper.ProjectTo<ChecklistResponseDTO>(
            context.Checklists
                .Where(c => c.Id == checklist.Id)
                .Include(c => c.ChecklistAnswerRows)
                .ThenInclude(a => a.Question)).FirstAsync();

        
        return result;
        // return mapper.Map<ChecklistResponseDTO>(checklist);
    }
}