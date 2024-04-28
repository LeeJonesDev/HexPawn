using System.ComponentModel.DataAnnotations;

namespace HexPawn.Models.Entities;

public class Player : BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string PlayerName { get; set; }

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }

    [MaxLength(255)]
    public string FistName { get; set; }

    [MaxLength(255)]
    public string LastName { get; set; }

    [Required]
    public DateOnly BirthDate { get; set; }

    public IEnumerable<Character> Characters { get; set; }

}
