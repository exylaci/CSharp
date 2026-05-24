using Microsoft.Extensions.Logging;
using Mobile.Services;
using Mobile.Services.Interfaces;
using Mobile.Settings;
using Mobile.ViewModels;

namespace Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(AppSettings.BaseApiUrl) });
        builder.Services.AddSingleton<ICustomerApiService, CustomerApiService>();
        builder.Services.AddSingleton<CustomersViewModel>();
        builder.Services.AddSingleton<CustomersViewModel>();
        builder.Services.AddSingleton<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}