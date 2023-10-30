using Domain.Entities.MicroServiceCore.Entities;
using FluentValidation;
using Infrastructure.Repositories.Implementations.MicroServiceCore.Repositories;
using Services.Abstractions.MicroServiceCore.Abstractions;
using Services.Contracts;
using Services.Implementations.MicroServiceCore.Implementations;
using Services.Repositories.Abstractions.MicroServiceCore.Repositories.Abstractions;
using WebApi.Validators;
namespace WebApi.Extensions;

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
