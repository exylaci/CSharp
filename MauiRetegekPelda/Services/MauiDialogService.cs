namespace MauiRetegekPelda.Services;

public sealed class MauiDialogService : IDialogService //A saját dialogus szerviz interfészünket implementálja
{
//A service nem tud semmit a UI-ról csak annyit tud, hogy valamit meg kell írnia

    private readonly Page _hostPage;    //konstruktorban kapja meg hova kell kiírnia

    public MauiDialogService(Page hostPage)
    {
        _hostPage = hostPage;
    }

    public Task ShowMessageAsync(string title, string message, string cancel = "OK") =>
        _hostPage.DisplayAlertAsync(title, message, cancel);
}