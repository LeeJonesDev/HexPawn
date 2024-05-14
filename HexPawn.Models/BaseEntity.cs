using System.ComponentModel.DataAnnotations;

namespace HexPawn.Models;

/// <summary>
/// Any model inheriting this class will be regestered as an entity in Entity Framework at App Startup in the ApplicationDbContext
/// </summary>
public abstract class BaseEntity
{
    [Key]
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? DeletedAt { get; set; } = null;
}
