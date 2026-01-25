using DependencyInjectedPattern.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectedPattern
{                                                                                   // (4)
    internal class Program                                                          //Így nem össze-vissza példányosítunk, spórolunk az erőforrással, mert
                                                                                    //az egyetlen létrejött példányt használjuk és adogatjuk át mindenkinek.
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();                   //Létrehozok egy szervz kollekciót, amibe belepakolgatom a függőség Patterneket
            services.AddSingleton<IAppSettings, AppSettings>();                     //Singleton az AppSettings
            services.AddTransient<IDateTimeProvider, SystemDateTimeProvider>();     //Transient a DateTimeProvider (Mindenegyes kérésnél, egy új példány kell.)

            services.AddTransient<IGreetingStrategy, HungarianGreetingStrategy>();  //Transient a Strategy. Mindegyiket ugyanarra az interfészre adom meg!
            services.AddTransient<IGreetingStrategy, EnglishGreetingStategy>();

            services.AddTransient<GreetingService>();                               //Aztán  az ezeket használó Szervíz-t.

            ServiceProvider provider = services.BuildServiceProvider();             //Végül le kell Build-elni.

            IAppSettings s1 = provider.GetRequiredService<IAppSettings>();          //(Csak bebizonyítjuk, hogy ugyanazt a Singletont használja, mind a kettő.)
            IAppSettings s2 = provider.GetRequiredService<IAppSettings>();          
            Console.WriteLine("Az appsettings ugyanaz a példány: " + Object.ReferenceEquals(s1, s2));

            GreetingService service = provider.GetRequiredService<GreetingService>();   //Az GreetingService-hez szükséges service lekérése
            Console.WriteLine(service.Greet("Elek"));                               //A servicen keresztűl a (korábban beállított default értékre) függvényhívás

            s1.Language = "en";                                                     //Váltás a beállításnak (nyelvnek) megfelelő funkcióra
            Console.WriteLine(service.Greet("Elek"));

            s1.Language = "ssss";
            Console.WriteLine(service.Greet("Elek"));                               //Nem száll el, a default nyelven köszön. :)
        }
    }
}
