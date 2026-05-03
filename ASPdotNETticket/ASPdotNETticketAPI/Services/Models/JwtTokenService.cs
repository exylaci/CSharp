using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ASPdotNETticketAPI.Configuration;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ASPdotNETticketAPI.Services.Models;

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtSettings jwtSettings; //Ahhoz, hogy típusosan tudjuk kiolvasni

    public JwtTokenService(IOptions<JwtSettings> jwtSettings)
    {
        this.jwtSettings = jwtSettings.Value;
    }

    public (string token, DateTime ExpiresAtUtc) CreateToken(AppUser user)
    {
        List<Claim> claims = new List<Claim> //User azonosítására, authorizációhoz fontos "claim"-ek
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role),
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()), //NuGet Microsoft.AspNetCore.Authentication.JwtBearer -t kell telepíteni
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //Guid.NewGuid()  generál egy random user ID-t.
        };
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)); //Szimmetrikus aláíró kulcs készítése
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        DateTime expiresAtUtc = DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationMinutes);
        SecurityToken token = new JwtSecurityToken( //Token készítése
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Issuer,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresAtUtc,
            signingCredentials: credentials);
        string tokenString = new JwtSecurityTokenHandler().WriteToken(token); //String formátumban a token
        return (tokenString, expiresAtUtc);
    }
}