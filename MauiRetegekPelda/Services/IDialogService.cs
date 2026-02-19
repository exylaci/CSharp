namespace MauiRetegekPelda.Services;

public interface IDialogService
{
    Task ShowMessageAsync(string title, string message, string cancel = "OK");
    //Aszinkron művelet, de Task-osítjuk
    
}