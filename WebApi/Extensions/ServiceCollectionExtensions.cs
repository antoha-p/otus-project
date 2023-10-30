using CoreService.WebApi.Validators;
using Domain.Entities.CoreService;
using FluentValidation;
using Infrastructure.Repositories.Implementations.MicroServiceCore.Repositories;
using Services.Abstractions.CoreService;
using Services.Contracts.CoreService;
using Services.Implementations.CoreService;
using Services.Repositories.Abstractions.CoreService;

namespace CoreService.WebApi.Extensions;

internal static class ServiceCollectionExtensions
{
    /// <summary>
    /// Метод-расширение для регистрации сервисов бизнес-логики по работе с данными
    /// </summary>
    public static IServiceCollection AddBLLServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationFormRepository, ApplicationFormRepository>()
                .AddScoped<IEFGenericRepository<ApplicationForm>, EFGenericRepository<ApplicationForm>>()
                .AddScoped<IEFGenericRepository<EventLogEntity>, EFGenericRepository<EventLogEntity>>()
                .AddScoped<IValidator<ApplicationFormDto>, ApplicationFormValidator>()
                .AddScoped<IEventLogService, EventLogService>();

        return services;
    }
}
