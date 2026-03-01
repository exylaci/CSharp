using GITdemoMAUI.ViewModels;
using Microsoft.Extensions.Logging;

namespace GITdemoMAUI;

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

        builder.Services.AddSingleton<IClock, SystemClock>();   //Beregisztráljuk a saját óránkat
        builder.Services.AddSingleton<HomeViewModel>();         //Létrehozatjuk a ViewModelünket  
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}


public interface IClock
{
    public DateTimeOffset Now { get; }
}

public sealed class SystemClock : IClock
{
    public DateTimeOffset Now
    {
        get => DateTimeOffset.Now; //Csak hogy csináljon is valamit a program.
    }
}