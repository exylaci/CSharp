namespace GITdemoMAUI.Services;

public interface INavigationService
{
    Task GoToAsync(string route, IDictionary<string, object>? parameters = null); //útvonal, Szótár: 
    Task GoBackAsync();
}