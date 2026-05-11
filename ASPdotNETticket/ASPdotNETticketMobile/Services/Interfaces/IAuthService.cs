using ASPdotNETticketMobile.Models.Auth;

namespace ASPdotNETticketMobile.Services.Interfaces;

public interface IAuthService   //A belépés kilépés folyamatát, és a bejelentkezett user alapadatainak kezelésére
{
    Task<AuthResponse?> LoginAsync(LoginRequest request);   //nullable, mert ha sikertelen a bejelentkezés
    Task LogoutAsync();
    Task<bool> IsLoggedInAsync();
    Task<string?> GetCurrentUserNameAsync();
    Task<string?> GetCurrentUserRoleAsync();
}