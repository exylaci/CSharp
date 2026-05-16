using System.ComponentModel.DataAnnotations;

namespace Api.Entities;

public class EmailAdrdess
{
    public int Id { get; set; }

    // [Required]
    // [EmailAddress]
    public string Email { get; set; } = string.Empty;
}