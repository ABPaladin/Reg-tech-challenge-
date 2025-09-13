using AutoMapper;
using Domain.DTO;
using Repository.Entities;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Checklist, ChecklistResponseDTO>();
        CreateMap<ChecklistQuestion, ChecklistQuestionDTO>();
        CreateMap<ChecklistAnswerRow, ChecklistAnswerDTO>()
            .ForMember(dto => dto.QuestionOrder, expression => 
                expression.MapFrom(r => r.Question.QuestionOrder))
            .ForMember(dto => dto.QuestionText, expression => 
                expression.MapFrom(r => r.Question.QuestionText))
            .ForMember(dto => dto.Recommendations, expression => 
                expression.MapFrom(r => r.Question.Recommendations));

        CreateMap<CompanyRegisterRequestDTO, Company>();
        CreateMap<Company, CompanyRegisterResponseDTO>();
        CreateMap<Company, CompanyLoginResponseDto>();

        CreateMap<CreateIncidentRequestDTO, Incident>();
        CreateMap<Incident, IncidentResponseDTO>()
            .ForMember(dto => dto.Status, expression => expression.MapFrom(r => r.Status.Name));

        CreateMap<AutomaticCheckAuditHeader, AutoCheckResponseDto>();
        CreateMap<AutomaticCheckAuditRow, AutoCheckResponseRowDto>()
            .ForMember(dto => dto.CheckName, expression => 
                expression.MapFrom(r => r.AutomaticCheck.Name))
            .ForMember(dto => dto.CheckOrder, expression => 
                expression.MapFrom(r => r.AutomaticCheck.CheckOrder));
    }
}