using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.MicroServiceCore.Entities;

public class EventLogEntity : IEntityId
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Дата возникновения события
    /// </summary>
    public DateTime CreateDt { get; set; }

    /// <summary>
    /// Описание события
    /// </summary>
    public string Description { get; set; }
}
