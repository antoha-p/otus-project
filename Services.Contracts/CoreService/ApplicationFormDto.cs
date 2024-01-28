using Domain.Entities.CoreService;

namespace Services.Contracts.CoreService;

/// <summary>
/// дто заявки,которую получает ядро от пользователя
/// </summary>
public class ApplicationFormDto:IEntityId
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? LastName { get; set; }
    /// <summary>
    /// ИНН
    /// </summary>
    public string? Inn { get; set; }
}
