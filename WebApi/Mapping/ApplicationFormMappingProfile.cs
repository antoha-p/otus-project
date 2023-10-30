using AutoMapper;
using Domain.Entities.CoreService;
using Services.Contracts.CoreService;
namespace CoreService.WebApi.Mapping;

internal class ApplicationFormMappingProfile:Profile
{
    public ApplicationFormMappingProfile()
    {
        CreateMap<ApplicationForm, ApplicationFormDto>()
            .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(d => d.SecondName, opt => opt.MapFrom(src => src.SecondName))
            .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(d => d.Inn, opt => opt.MapFrom(src => src.Inn));
        CreateMap<ApplicationFormDto, ApplicationForm>()
            .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(d => d.SecondName, opt => opt.MapFrom(src => src.SecondName))
            .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(d => d.Inn, opt => opt.MapFrom(src => src.Inn))
            .ForMember(d => d.FullName, opt => opt.MapFrom(src => GetFullName(src)));
    }
    private string GetFullName(ApplicationFormDto dto)=>dto.FirstName+ " "+ dto.SecondName+" "+ dto.LastName;
}
