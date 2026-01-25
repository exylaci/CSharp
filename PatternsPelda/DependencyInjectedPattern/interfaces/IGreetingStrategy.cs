namespace DependencyInjectedPattern.interfaces
{                                               // (1)
    public interface IGreetingStrategy          //Mivel minden osztály ugyanazokat a feladatokat kell végrehejtsa, készítünk rá egy strategy interfészt.
    {
        string LanguageCode { get; }
        string BuildGreeting(string name);
    }
}
