using Api.Data;
using Api.Repositories;
using Api.Repositories.Interfaces;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); });
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddControllers(); // A Controller-eket általában nem kell külön regisztrálni, az ASP.NET Core automatikusan kezeli őket.

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection(); //Fejlesztés közben nem irányítja át a sima http kéréseket https-re
}

app.MapControllers(); //Összeköti az ASP.NET Core routing rendszerét a Controller-ekkel. Ha nincs ott akkor az API elindul, de minden endpoint 404 lesz

app.Run();