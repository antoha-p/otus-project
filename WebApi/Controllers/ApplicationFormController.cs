using AutoMapper;
using Domain.Entities.MicroServiceCore.Entities;
using FluentValidation;
using Services.Contracts;
using Services.Repositories.Abstractions.MicroServiceCore.Repositories.Abstractions;
using WebApi.Abstractions;
namespace WebApi.Controllers;

public class ApplicationFormController : BaseCRUDController<ApplicationForm,ApplicationFormDto>
{
    public ApplicationFormController(IEFGenericRepository<ApplicationForm> baseRepo, IMapper mapper,
                                     IValidator<ApplicationFormDto> createValidator, IValidator<ApplicationFormDto> updateValidator) 
                                     :base(baseRepo,mapper,createValidator,updateValidator)
    {

    }
}
