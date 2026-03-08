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
}