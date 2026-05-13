using ASPdotNETcalculator.API.Data;
using ASPdotNETcalculator.API.Services.Interfaces;
using ASPdotNETcalculator.API.Services.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(); //Add services to the container.
builder.Services.AddControllers(); //Hozzá kell adni a kontrollereket, anélkül nem működik
builder.Services.AddScoped<ICalculatingService, CalculatingService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
} // Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// app.UseAuthorization(); //Jogosultság kezeléshez kell
app.MapControllers(); //A végpontok eléréséhez kell a map kontroller
app.Run();