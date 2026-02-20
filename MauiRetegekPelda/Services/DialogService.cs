namespace MauiRetegekPelda.Services;

public sealed class DialogService : IDialogService //A saját dialogus szerviz interfészünket implementálja
{
//A service nem tud semmit a UI-ról csak annyit tud, hogy valamit meg kell írnia

    private readonly ICurrentPageAccessor _pageAccessor;

    public DialogService(ICurrentPageAccessor pageAccessor)
    {
        _pageAccessor = pageAccessor;
    }

    public Task ShowMessageAsync(string title, string message, string cancel = "OK")
    {
        Page page = _pageAccessor.CurrentPage
                    ?? Shell.Current?.CurrentPage
                    ?? Application.Current?.MainPage;

        if (page is null)
        {
            return Task.CompletedTask;  
        }
        
        return page.DisplayAlertAsync(title, message, cancel);
    }
}