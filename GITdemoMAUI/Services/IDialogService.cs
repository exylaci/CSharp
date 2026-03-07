namespace GITdemoMAUI.Services;

public interface IDialogService
{
    Task<bool> ShowConfirmationRequestAsync(string title, string message, string accept = "Igen", string cancel = "Nem");
}