using DependencyInjectedPattern.interfaces;
using System;
using System.Collections.Generic;

namespace DependencyInjectedPattern
{                                                                           // (3)
    public sealed class GreetingService                                     //A dependency injection-t befogadó szervíz osztály, 
    {
        private readonly IAppSettings _settings;                            //A kintről kapott függíségek
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly Dictionary<string, IGreetingStrategy> _strategies;

        public GreetingService(IAppSettings settings, IDateTimeProvider provider, IEnumerable<IGreetingStrategy> strategies)
        {                                                                   //Mindig itt a konstruktorban kapja meg a függőségeket.
                                                                            //Mindig interfész típust használunk a poliformizmus előnyeit.
            _settings = settings;
            _dateTimeProvider = provider;
            _strategies = new Dictionary<string, IGreetingStrategy>();

            foreach (IGreetingStrategy item in strategies)
            {
                _strategies[item.LanguageCode] = item;
            }

            AppSettings s = settings as AppSettings;
            if (s != null)
            {
                s.LanguageChanged += OnLanguageChanged;                     //OnLanguageChanged funkciónkat feliratkozzuk az AppSettings
                                                                            //osztály LanguageChanged eseménykezelő listájára.
            }
        }

        public string Greet(string name)
        {
            IGreetingStrategy strategy;
            if (_strategies.TryGetValue(_settings.Language, out strategy) == false) //Mindig ellenőrizzük, hogy van-e startegy.
            {
                strategy = _strategies["hu"];                               //Ha nincs, akkor beállítjuk a default értéket.
            }

            string greeting = strategy.BuildGreeting(name);
            string timestamp = _dateTimeProvider.Now.ToString("HH:mm:ss");

            return "[" + timestamp + "] " + greeting;
        }

        private void OnLanguageChanged(string newLanguage)                  //Ezt a függvényt hívja meg az AppSettings EVENT-je.
        {
            Console.WriteLine("[Observer] Nyelv megváltozott! " + newLanguage); 
        }
    }
}
