using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.CoreService;

public class EventLogEntity : IEntityId
{
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Дата возникновения события
    /// </summary>
    public DateTime CreateDt { get; set; }

    /// <summary>
    /// Описание события
    /// </summary>
    public string Description { get; set; }
}
