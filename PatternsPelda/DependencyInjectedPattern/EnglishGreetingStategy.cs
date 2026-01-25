using DependencyInjectedPattern.interfaces;

namespace DependencyInjectedPattern
{                                                               // (2)
    internal class EnglishGreetingStategy : IGreetingStrategy   //Az interfészt megvalósító különböző osztályok elkészítése.
    {
        public string LanguageCode => "en";

        public string BuildGreeting(string name)
        {
            return "Hi " + name + ",";
        }
    }
}
