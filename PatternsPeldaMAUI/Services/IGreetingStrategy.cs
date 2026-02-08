namespace PatternsPeldaMAUI.Services;

public interface IGreetingStrategy
{
    string LanguageCode { get; }
    string BuildGreeting(string name);
}