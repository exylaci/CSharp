using System.Text;
using ASPdotNETticketAPI.Configuration;
using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Services.Interfaces;
using ASPdotNETticketAPI.Services.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context => //Validációs hiba esetén egy saját, az általunk megfogalmazott hibajelzést küldi vissza
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validációs hiba!",
                Detail = "A keresés egy vagy több mezője hibás",
                Instance = context.HttpContext.Request.Path
            };
            return new BadRequestObjectResult(problemDetails);
        };
    }); //Hozzá kell adni a kontrollereket, anélkül nem működik

//A connection stringet az appsettings.jason-ből olvassuk ki
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("A default connection string nincs beállítva."); //Ha nem tudjuk beolvasni az végzetes hiba.

builder.Services.AddDbContext<AppDbContext>(options => options // A database context berakása a dependency konténerbe
    .UseSqlite(connectionString) // UseSqLite - sql providert akarunk használni
    .UseSeeding((context, _) => SeedData.Initialize((AppDbContext)context)) //A SeedData.cs-ben felvett kezdeti adatok betöltése
    .UseAsyncSeeding((context, _, cancellationToken) => SeedData.InitializeAsync((AppDbContext)context, cancellationToken)));


builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));
//Be kell kötni a JasonWebTokenbe az autentikációt és a default sémát is ugyanúgy beállítani hogy az autorize dekorátorral működhessen:  Ehhez viszont kell a jason webtoken teljes settings, le kell tujuk kérni
JwtSettings jwtSettings = builder.Configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>()
                          ?? throw new InvalidOperationException("A jwt settings szekvencia nincs megfelelően beállítva!"); //Ha nem létezik az objektum, security okból, kötelező elszállnia a programnak.
if (string.IsNullOrEmpty(jwtSettings.Key))
{
    throw new InvalidOperationException("A jwt settings szekvencia nincs megfelelően beállítva!"); //Ha üres adattal tér vissza, akkor is szálljon el
}

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();



builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication(); //Előbb a felhasználó ellenőrzése aztámn a jogosultság megadása 
app.UseAuthorization(); //Jogosultság kezeléshez kell
app.MapControllers(); //A végpontok eléréséhez kell a map kontroller
app.Run();