using System.ComponentModel.DataAnnotations;

namespace ASPdotNETticketAPI.Dtos.Auth;

public class RegisterRequestDto
//Atribútumos validációs dekorátorokkal védjük a kapott adatok ellenőrzésével már a bevitelükkor
{
    [Required(ErrorMessage = "A telejs név megadása kötelező")] //Kötelező adat
    [StringLength(100, MinimumLength = 3, ErrorMessage = "A név legalább 3 és max 100 karakter kell legyen")] //min 3 max 100 karakter
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email címet kötelező megadni")]
    [EmailAddress(ErrorMessage = "Hibás email cím formátum")]
    [StringLength(150, ErrorMessage = "Az email cím nem lehet hosszabb 150 karaktermél")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A jelszó megadása kötelező")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "A legalább 8 karakter hosszú kell legyen, de nem lehet hosszabb 100 karakternél")]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d]).{8,}"
        , ErrorMessage = "A jelszó legalább 8 karakter, amiben kelllegyen kisbetű, nagybetű, szám és speciális karakter.")] //RegExp kifejezés is lehet
    public string Password { get; set; } = string.Empty;
}