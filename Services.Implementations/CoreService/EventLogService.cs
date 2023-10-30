using System.Diagnostics;
using Domain.Entities.CoreService;
using Services.Abstractions.CoreService;
using Services.Repositories.Abstractions.CoreService;

namespace Services.Implementations.CoreService;

/// <summary>
/// Сервис лога событий
/// </summary>
public sealed class EventLogService : IEventLogService
{
    private readonly IEFGenericRepository<EventLogEntity> _eventLogRepo;
    public EventLogService(IEFGenericRepository<EventLogEntity> eventLogRepo)
    {
        _eventLogRepo = eventLogRepo ?? throw new ArgumentNullException(nameof(eventLogRepo));
    }
    /// <summary>
    /// Добавить событие в журнал
    /// </summary>
    /// <param name="description"></param>
    public async Task AddEventAsync(string description)
    {
        EventLogEntity log = new() { CreateDt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), Description = description };
        try
        {
            await _eventLogRepo.CreateAsync(log);
        }
        catch (Exception e)
        {
            Debug.Fail("Ошибка сохранения лога", e.ToString());
        }
    }
}
