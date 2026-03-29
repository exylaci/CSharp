using ASPdotNETticketAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(); //Hozzá kell adni a kontrollereket, anélkül nem működik

//A connection stringet az appsettings.jason-ből olvassuk ki
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("A default connection string nincs beállítva."); //Ha nem tudjuk beolvasni az végzetes hiba.

builder.Services.AddDbContext<AppDbContext>(options => options      // A database context berakása a dependency konténerbe
    .UseSqlite(connectionString)                                    // UseSqLite - sql providert akarunk használni
    .UseSeeding((context, _) => SeedData.Initialize((AppDbContext)context))         //A SeedData.cs-ben felvett kezdeti adatok betöltése
    .UseAsyncSeeding((context, _, cancellationToken) => SeedData.InitializeAsync((AppDbContext)context, cancellationToken)));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization(); //Jogosultság kezeléshez kell
app.MapControllers(); //A végpontok eléréséhez kell a map kontroller
app.Run();