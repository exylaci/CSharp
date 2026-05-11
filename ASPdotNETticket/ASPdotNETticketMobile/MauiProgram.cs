using ASPdotNETticketMobile.Services.Interfaces;
using ASPdotNETticketMobile.Services.Models;
using ASPdotNETticketMobile.ViewModels;
using ASPdotNETticketMobile.Views;
using Microsoft.Extensions.Logging;

namespace ASPdotNETticketMobile;

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

        //Ahogyan először szükség lesz rá, olyan sorrendben adjuk hozzá a service-eket.
        builder.Services.AddSingleton<ITokenStorageService, TokenStorageService>(); //Tárolók, logikák - Singleton
        builder.Services.AddSingleton<IApiClientFactory, ApiClientFactory>();
        builder.Services.AddSingleton<IAuthService, AuthService>();

        builder.Services.AddTransient<LoginViewModel>(); //oldalak, nézetek - Transient
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomePage>();

        builder.Services.AddSingleton<AppShell>(); //Ugyanazt az egy shell-t is sok helyen várjuk

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}