using ASPdotNETticketAPI.Dtos.Auth;
using ASPdotNETticketAPI.Services.Models;

namespace ASPdotNETticketAPI.Services.Interfaces;

public interface IAuthService
//Regisztrációhoz, loginhez, aktuális user lekérdezésekhez
{
    Task<ServiceResult<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
    Task<ServiceResult<AuthResponseDto>> LoginAsync(LoginRequestDto dto);
    Task<ServiceResult<CurrentUserDto>> GetCurrentUserAsync(int userId);
}