namespace ASPdotNETticketMobile.Models.Auth;

public class LoginRequest //Azért használunk külön modelt és nem a közös DTO-t, mert nem feltétlen kell a frontendnek és a backendnek ugyanabból a DTO-ból "táplálkozik". (Ha egyben fejlesztjük, akkor lehet közös, de pl. ha más programnyelven íródnak, nem is tudnák felhasználni.)
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; //A jelszó sem feltétlenül pure textben van átküldve, meg lehet előtte has-selni egy a backendtől kapott kóddal.
}