using ASPdotNETticketMobile.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ASPdotNETticketMobile;

public partial class App : Application
{
    private readonly IAuthService authService;
    private readonly AppShell shell;

    public App(AppShell shell, IAuthService authService)
    {
        InitializeComponent();
        this.shell = shell;
        this.authService = authService;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window window = new Window(shell);
        _ = InitializeAsync(); //Mert a create window-nál nem illik await-elni
        return window;
    }

    private async Task InitializeAsync()
    {
        bool isLoggedIn = await authService.IsLoggedInAsync();
        if (isLoggedIn)
        {
            await shell.GoToAsync($"//home");
        }
        else
        {
            await shell.GoToAsync($"//login");
        }
    }
}