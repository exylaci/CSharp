using System.Diagnostics;
using System.Windows.Input;
using ASPdotNETticketMobile.Models.Auth;
using ASPdotNETticketMobile.Services.Interfaces;

namespace ASPdotNETticketMobile.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly IAuthService authService;
    private string email = string.Empty;
    private string password = string.Empty;

    public string Email
    {
        get => email;
        set
        {
            if (SetField(ref email, value))
            {
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }
    }

    public string Password
    {
        get => password;
        set
        {
            if (SetField(ref password, value))
            {
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }
    }

    public LoginViewModel(IAuthService authService)
    {
        this.authService = authService;
        Title = "Bejelentkezés";
        LoginCommand = new Command(async () => await LoginAsync(), CanExecuteLogin);
    }

    public ICommand LoginCommand { get; }

    private bool CanExecuteLogin()
    {
        return !IsBusy && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
    }


    private async Task LoginAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true; //Beállítjuk true-ra, mert most kezdődik el az egész folyamat
            ErrorMessage = string.Empty; //Egyelőre nincs hibaüzenet, a régit töröljük (ha volt egyáltalán).
            ((Command)LoginCommand).ChangeCanExecute();
            LoginRequest request = new LoginRequest //Login request előkészítése, példányosítása
            {
                Email = Email.Trim(), //adatok beállítása
                Password = Password
            };
            AuthResponse? result = await authService.LoginAsync(request);
            if (result is null)
            {
                ErrorMessage = "Sikertelen bejelentkezés. Ellenőrizze az e-mail címet és a jelszót!";
                return; //Marad a login oldalon
            }

            await Shell.Current.GoToAsync("//home"); //sikeres bejelentkezés esetén Shell navigácó a főoldalra
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            ErrorMessage = "Váratlan hiba történt" + ex.Message;
        }
        finally
        {
            IsBusy = false; //Lefutott, használhatja más 
            ((Command)LoginCommand).ChangeCanExecute(); //újra aktívvá válik a gomb is
        }
    }
}