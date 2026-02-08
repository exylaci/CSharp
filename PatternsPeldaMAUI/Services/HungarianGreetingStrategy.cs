namespace PatternsPeldaMAUI.Services;

internal class HungarianGreetingStrategy : IGreetingStrategy
{
    public string LanguageCode => "hu";

    public string BuildGreeting(string name)
    {
        return "Szia " + name + "!";
    }
}