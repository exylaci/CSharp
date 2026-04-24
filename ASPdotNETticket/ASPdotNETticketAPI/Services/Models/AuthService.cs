using ASPdotNETticketAPI.Constants;
using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Auth;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Services.Models;

public class AuthService : IAuthService
{
    private readonly AppDbContext dbContext;
    private readonly IPasswordHasher<AppUser> passwordHasher; //A beépített hashert használjuk, ez annyirra nem biztonságos, de beépített egyszerű használni
    private readonly IJwtTokenService jwtTokenService;

    public AuthService(AppDbContext dbContext, IPasswordHasher<AppUser> passwordHasher, IJwtTokenService jwtTokenService)
    {
        this.dbContext = dbContext;
        this.passwordHasher = passwordHasher;
        this.jwtTokenService = jwtTokenService;
    }


    public async Task<ServiceResult<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto)
    {
        string normalizedFullName = dto.FullName.Trim();
        string normalizedEmail = dto.Email.Trim().ToLowerInvariant();

        bool emailAlreadyExists = await dbContext.Users.AnyAsync(u => u.Email == normalizedEmail);

        if (emailAlreadyExists)
        {
            return ServiceResult<AuthResponseDto>.Validation(nameof(dto.Email), "Ezzel az email címmel már regisztráltak.");
        }

        AppUser user = new AppUser
        {
            FullName = normalizedFullName,
            Email = normalizedEmail,
            Role = RoleNames.User,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return ServiceResult<AuthResponseDto>.Success(CreateAuthResponse(user));
    }

    public async Task<ServiceResult<AuthResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        string normailzedEmai = dto.Email.Trim().ToLowerInvariant();
        AppUser? user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == normailzedEmai);

        if (user == null)
        {
            return ServiceResult<AuthResponseDto>.Validation("creditials", "Hibás email cím, vgy jelszó!");
        }

        if (!user.IsActive)
        {
            return ServiceResult<AuthResponseDto>.Validation("creditials", "A user jelenleg inaktív");
        }

        PasswordVerificationResult verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return ServiceResult<AuthResponseDto>.Validation("creditials", "Hibás jelszó!");
        }

        if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);
            await dbContext.SaveChangesAsync();
        }

        return ServiceResult<AuthResponseDto>.Success(CreateAuthResponse(user));
    }

    public async Task<ServiceResult<CurrentUserDto>> GetCurrentUserAsync(int userId)
    {
        AppUser? user = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return ServiceResult<CurrentUserDto>.NotFound("A felhasználó nem telálható!");
        }

        CurrentUserDto dto = new CurrentUserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = RoleNames.User,
            CreatedAt = DateTime.UtcNow,
            IsActive = user.IsActive
        };
        return ServiceResult<CurrentUserDto>.Success(dto);
    }

    private AuthResponseDto CreateAuthResponse(AppUser user)
    {
        var tokenResult = jwtTokenService.CreateToken(user); //Itt állítjuk össze a token generálásból kiszervezett tokent
        return new AuthResponseDto
        {
            UserId = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Role = RoleNames.User,
            Token = tokenResult.token,
            ExpiresAtUtc = tokenResult.ExpiresAtUtc
        };
    }
}