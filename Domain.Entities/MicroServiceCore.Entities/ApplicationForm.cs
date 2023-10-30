using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Domain.Entities.MicroServiceCore.Entities;

/// <summary>
/// заявка,которую получает ядро от пользователя
/// </summary>
[DebuggerDisplay("{ToDebugString()}")]
public class ApplicationForm : IEntityId
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    /// <summary>
    /// ИНН
    /// </summary>
    public string? Inn { get; set; }

    public string ToDebugString() => $"{Id} | {FullName} | {Inn} ";
}

