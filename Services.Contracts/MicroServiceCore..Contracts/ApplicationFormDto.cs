using Domain.Entities.MicroServiceCore.Entities;

namespace Services.Contracts;

/// <summary>
/// дто заявки,которую получает ядро от пользователя
/// </summary>
public class ApplicationFormDto:IEntityId
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? LastName { get; set; }
    /// <summary>
    /// ИНН
    /// </summary>
    public string? Inn { get; set; }
}
