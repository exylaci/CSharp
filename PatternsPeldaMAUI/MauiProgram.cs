using Microsoft.Extensions.Logging;
using PatternsPeldaMAUI.Services;
using PatternsPeldaMAUI.ViewModels;

namespace PatternsPeldaMAUI;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<IAppSettings, AppSettings>();
        builder.Services.AddTransient<IDateTimeProvider, SystemDateTimeProvider>();

        builder.Services.AddTransient<IGreetingStrategy, HungarianGreetingStrategy>();
        builder.Services.AddTransient<IGreetingStrategy, EnglishGreetingStrategy>();

        builder.Services.AddTransient<GreetingService>();

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AppShell>();
        return builder.Build();
    }
}