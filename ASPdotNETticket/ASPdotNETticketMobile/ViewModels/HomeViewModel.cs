using ASPdotNETticketMobile.Services.Interfaces;

namespace ASPdotNETticketMobile.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly IAuthService authService;
    private string welcomeText = string.Empty;
    private string roleText = string.Empty;
    public Command LogoutCommand { get; set; }

    public string WelcomeText
    {
        get => welcomeText;
        set => SetField(ref welcomeText, value);
    }

    public string RoleText
    {
        get => roleText;
        set => SetField(ref roleText, value);
    }


    public HomeViewModel(IAuthService authService)
    {
        this.authService = authService;
        Title = "Kezdőlap";
        LogoutCommand = new Command(async () => await LogoutAsync());
    }


    public async Task InitializeAsync()
    {
        string? fullname = await authService.GetCurrentUserNameAsync();
        string? role = await authService.GetCurrentUserNameAsync();

        WelcomeText = string.IsNullOrWhiteSpace(fullname) ? "Sikeres bejelentkezés" : $"Üdv {fullname}!";
        RoleText = string.IsNullOrWhiteSpace(role) ? string.Empty : $"Szerepkör: {role}";
    }

    private async Task LogoutAsync()
    {
        await authService.LogoutAsync(); //Kijelentkezteti a felhasználót
        await Shell.Current.GoToAsync("//login"); //Átnavigál a ligin oldalra
    }
}