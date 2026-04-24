using System.Security.Claims;
using ASPdotNETticketAPI.Dtos.Auth;
using ASPdotNETticketAPI.Services.Interfaces;
using ASPdotNETticketAPI.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPdotNETticketAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [AllowAnonymous] //Jelezi, hogy ehhez nem kell authentikáció
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterRequestDto dto)
    {
        var result = await authService.RegisterAsync(dto);

        if (!result.IsSuccess)
        {
            return CreateAtActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [AllowAnonymous] //Jelezi, hogy ehhez nem kell authentikáció
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequestDto dto)
    {
        var result = await authService.LoginAsync(dto);

        if (!result.IsSuccess)
        {
            return CreateAtActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [Authorize] //Jelezi, hogy ehhez nem kell authentikáció
    [HttpGet("me")]
    public async Task<ActionResult<CurrentUserDto>> Me([FromBody] LoginRequestDto dto)
    // Authentikálva van, tehát a kliens a jason web tokent vissza kell nekünk adja, és az abban tárolt információkból kinyerhető a name identifier  clameből ki tudjuk szedni a user azonosítóját, ha megvan az ID-ja, akkor a user entity segítségével meg tudjuk keresni
    {
        string? userIdClam = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdClam, out int userId))
        {
            return Unauthorized(new { message = "A token nem tartalmaz érvényes user azonosítót!" });
        }

        var result = await authService.GetCurrentUserAsync(userId);

        if (result.IsNotFound)
        {
            return NotFound(new { message = result.Message });
        }

        return Ok(result.Data);
    }
    
    
    private ActionResult<AuthResponseDto> CreateAtActionResultFromServiceResult<T>(ServiceResult<T> result)
    {
        if (result.IsSuccess)
        {
            return NotFound(new { message = result.Message });
        }

        return ValidationProblem(new ValidationProblemDetails(result.Errors));
    }
}