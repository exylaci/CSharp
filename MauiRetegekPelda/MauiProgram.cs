using MauiRetegekPelda.Pages;
using MauiRetegekPelda.Services;
using MauiRetegekPelda.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiRetegekPelda;

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

        //
        // A MauiProgram.cs kell legyen a központ.
        //  Nem jó, hogy a Page rak össze mindent, mindent konstruktorban injectionban kell kapnia.
        //  És a ViewModel-nek is. 
        //  ->Kevesebb példányosítás, könyebb a későbbi módosítás
        //
        // A szervíz rétegben levő "pointer" (ICurrentPageAccessor) mutat az aktív Pagere,
        //  a dialog service pedig ezen keresztűl mutatja a dialogot, ahol lehet megjeleníteni bármit.

        // Itt döntjük el, miből mennyi példány kell:
        builder.Services.AddSingleton<ICurrentPageAccessor, CurrentPageAccessor>();
        //Az aktuális oldalunkra mutató Accessort soha sem kell újrapéldányosítani, tehát legyen Singleton 

        builder.Services.AddSingleton<IDialogService, DialogService>();
        //dialógus ablakból is elég csak 1 darab

        builder.Services.AddTransient<ContactEditorCleanViewModel>();
        //Minden egyes Page-nek saját ViewModell kell, mert ebben tárolódik az adott Page állapota.

        builder.Services.AddTransient<ContactEditorModelViewDependencyInversionPage>();
        //Page-ből nyilván több is van.

        builder.Services.AddSingleton<AppShell>(); //Kódbol adjuk hozzá

        

        //létre kell hozni a szervízt szingleton ként :
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        
        //létre kell hozni a viewmodel-eket és a page-eket tranziensként :
        builder.Services.AddTransient<ContactEditorNavigationViewModel>();
        builder.Services.AddTransient<ContactSummaryViewModel>();
        builder.Services.AddTransient<ContactEditorNavigationPage>();
        builder.Services.AddTransient<ContactSummaryPage>();
   
        //még mielőtt a Buildelés elkezdődne, kell beállítani mindent.

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}