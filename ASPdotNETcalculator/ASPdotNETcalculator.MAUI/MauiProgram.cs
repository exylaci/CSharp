using ASPdotNETcalculator.MAUI.Services.Interfaces;
using ASPdotNETcalculator.MAUI.Services.Models;
using ASPdotNETcalculator.MAUI.ViewModels;
using ASPdotNETcalculator.MAUI.Pages;
using Microsoft.Extensions.Logging;

namespace ASPdotNETcalculator.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<IOperationService, OperationService>();
        
        builder.Services.AddTransient<CalculatorViewModel>();
        builder.Services.AddTransient<CalculatorPage>();
        
        builder.Services.AddSingleton<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}