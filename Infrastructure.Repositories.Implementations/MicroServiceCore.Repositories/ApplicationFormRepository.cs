using Domain.Entities.MicroServiceCore.Entities;
using Infrastructure.EntityFramework.MicroServiceCore;
using Services.Repositories.Abstractions.MicroServiceCore.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations.MicroServiceCore.Repositories;

public class ApplicationFormRepository : EFGenericRepository<ApplicationForm>, IApplicationFormRepository
{
    public ApplicationFormRepository(MicroServiceCoreDBContext context) : base(context) { }
}
