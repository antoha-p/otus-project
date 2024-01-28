using Domain.Entities.CoreService;
using Infrastructure.EntityFramework.CoreService;
using Services.Repositories.Abstractions.CoreService;

namespace Infrastructure.Repositories.Implementations.MicroServiceCore.Repositories;

public class ApplicationFormRepository : EFGenericRepository<ApplicationForm>, IApplicationFormRepository
{
    public ApplicationFormRepository(CoreDBContext context) : base(context) { }
}
