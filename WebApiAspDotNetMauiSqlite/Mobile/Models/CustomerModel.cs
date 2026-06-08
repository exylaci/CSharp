using System.ComponentModel.DataAnnotations;

namespace Mobile.Models;

public class CustomerModel //frontendben használt modell (kisebb projektnél elegendő a DTO is)
{
    [Required(ErrorMessage = "Az e-mail cím megadása kötelező")]
    [EmailAddress(ErrorMessage = "Hibás e-mail cím formátum")]
    [StringLength(50, ErrorMessage = "Az e-mail cím maximum 50 karakter hosszú lehet ")] //A Validator.TryValidateObject -tel lehet ellenőriztatni a validátor annotációk teljesülését.
    [Display(Name = "E-mail cím")] //Az atribútum felhasználó barát elnevezése. Validációt sértő hibaüzeneteknél "Email" helyett azt írja be hogy "E-mail cím". Az xaml Binding-ra nincs hatással.
    public string Email { get; set; } = string.Empty; //kezdő érték, hogy ne kelljen a null-lal foglalkozni
}