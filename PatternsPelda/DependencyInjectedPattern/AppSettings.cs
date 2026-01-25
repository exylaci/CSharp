using DependencyInjectedPattern.interfaces;
using System;

namespace DependencyInjectedPattern
{
    public sealed class AppSettings : IAppSettings
    {
        private string language;
        public event Action<string> LanguageChanged;    //Observer event

        public string Language
        {
            get => language;
            set
            {
                language = value;
                Action<string> handler = LanguageChanged;
                if (handler != null)
                {
                    handler(language);
                }
            }
        }


        public AppSettings()
        {
            Language = "hu";                            //beállítja a "hu"-t defailt értéknek.
        }
    }
}
