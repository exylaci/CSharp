namespace GITdemoMAUI.Services;

public sealed class DialogService : IDialogService
{
    private readonly ICurrentPageAccessor _pageAccessor;

    public DialogService(ICurrentPageAccessor pageAccessor)
    {
        _pageAccessor = pageAccessor;
    }

    public Task<bool> ShowConfirmationRequestAsync(string title, string message,
        string accept = "Igen", string cancel = "Nem")
    {
        Page page = _pageAccessor.CurrentPage
                    ?? Shell.Current?.CurrentPage
                    ?? Application.Current?.MainPage;
        if (page is null)
        {
            return Task.FromResult(false);
        }

        return page.DisplayAlertAsync(title, message, accept, cancel);
    }

    public Task ShowMessageAsync(string title, string message, string ok = "OK") =>
        InvokeOnUiAsync(() => GetMainPage().DisplayAlert(title, message, ok));

    public Task<bool> ConfirmAsync(string title, string message, string accept = "OK", string cancel = "Mégsem")
        => InvokeOnUiAsync(() => GetMainPage().DisplayAlert(title, message, accept, cancel));

    public Task ShowErrorAsync(string message, string title = "Hiba")
        =>InvokeOnUiAsync(() =>GetMainPage().DisplayAlert(title, message,"OK"));

    private static Task InvokeOnUiAsync(Func<Task> action)
    {
        return MainThread.InvokeOnMainThreadAsync(action);
    }

    private static Task<T> InvokeOnUiAsync<T>(Func<Task<T>> action)
    {
        return MainThread.InvokeOnMainThreadAsync(action);
    }

    private static Page GetMainPage()
    {
        Page page = Application.Current.MainPage;
        if (page is null)
        {
            throw new InvalidOperationException("A MainPage Nem elérhető. Azaz null az Application.Current.MainPage");
        }

        return page;
    }

}