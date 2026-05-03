using ASPdotNETticketAPI.Entities;

namespace ASPdotNETticketAPI.Services.Interfaces;

public interface IJwtTokenService
//A token generálását külön vesszük, hogy az autentikációs szervíz ne legyen túlterhelve
{
    (string token, DateTime ExpiresAtUtc) CreateToken(AppUser user); //Tokennek mindig kell legyen lejárati ideje 
}