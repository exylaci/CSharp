namespace PatternsPeldaMAUI.Services;

internal class EnglishGreetingStrategy : IGreetingStrategy //Az interfészt megvalósító különböző osztályok elkészítése.
{
    public string LanguageCode => "en";

    public string BuildGreeting(string name)
    {
        return "Hi " + name + ",";
    }
}