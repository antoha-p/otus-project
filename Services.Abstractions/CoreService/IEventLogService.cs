namespace Services.Abstractions.CoreService;

public interface IEventLogService
{
    /// <summary>
    /// Добавить событие в журнал
    /// </summary>
    /// <param name="description"></param>
    Task AddEventAsync(string description);
}
