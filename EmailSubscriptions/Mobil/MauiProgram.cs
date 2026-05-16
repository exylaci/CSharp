using Microsoft.Extensions.Logging;
using Mobil.Pages;
using Mobil.Services;
using Mobil.Services.Inerfaces;
using Mobil.Settings;
using Mobil.ViewModels;

namespace Mobil;

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

        builder.Services.AddSingleton<RegistrationApiService>();
        builder.Services.AddHttpClient<IRegistrationApiService, RegistrationApiService>(client =>
        {
            client.BaseAddress = new Uri(AppSettings.BaseApiUrl);
        });

        builder.Services.AddSingleton<EmailsViewModel>();

        builder.Services.AddSingleton<EmailsPage>();


        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}






