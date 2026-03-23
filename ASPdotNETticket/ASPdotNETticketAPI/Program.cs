var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(); //Hozzá kell adni a kontrollereket, anélkül nem működik

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization(); //Jogosultság kezeléshez kell
app.MapControllers();   //A végpontok eléréséhez kell a map kontroller
app.Run();