using System.ComponentModel.DataAnnotations;

namespace ASPdotNETticketAPI.Dtos.Auth;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Email címet kötelező megadni")]
    [EmailAddress(ErrorMessage = "Hibás email cím formátum")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A jelszó megadása kötelező")]
    public string Password { get; set; } = string.Empty;
}