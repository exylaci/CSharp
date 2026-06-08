using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public class CustomerDto
{
    [Required(ErrorMessage = "Az e-mail cím megadása kötelező")]
    [EmailAddress(ErrorMessage = "Hibás e-mail cím formátum")]
    [StringLength(50, ErrorMessage = "Az e-mail cím maximum 50 karakter hosszú lehet")] //Ha ezek a szabályok sérülnek, akkor az [ApiController] hatására automatikusan 400 BadRequest-et ad vissza
    public string Email { get; set; } = string.Empty;
}