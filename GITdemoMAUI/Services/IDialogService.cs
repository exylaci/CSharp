namespace GITdemoMAUI.Services;

public interface IDialogService
{
    Task<bool> ShowConfirmationRequestAsync(string title, string message, string accept = "Igen", string cancel = "Nem");
    
    Task ShowMessageAsync(string title, string message, string ok = "OK");
    Task<bool> ConfirmAsync(string title, string message, string accept = "OK", string cancel = "Mégsem");
    Task ShowErrorAsync(string message, string title = "Hiba");

}