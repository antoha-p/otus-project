using AutoMapper;
using CoreService.WebApi.Abstractions;
using Domain.Entities.CoreService;
using FluentValidation;
using Services.Abstractions.Masstransit;
using Services.Contracts.CoreService;
using Services.Repositories.Abstractions.CoreService;

namespace CoreService.WebApi.Controllers;

public class ApplicationFormController : BaseCRUDController<ApplicationForm,ApplicationFormDto>
{
    public ApplicationFormController(IEFGenericRepository<ApplicationForm> baseRepo, IMapper mapper,
                                      IValidator<ApplicationFormDto> createValidator, IValidator<ApplicationFormDto> updateValidator,
                                      IMassTransitHelper massTransit)
                                      : base(baseRepo, mapper, createValidator, updateValidator, massTransit){}
}
