using ASPdotNETcalculator.MAUI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ASPdotNETcalculator.MAUI;

public partial class App : Application
{
    private readonly IOperationService _operationService;
    private readonly AppShell _shell;

    public App(AppShell shell, IOperationService operationService)
    {
        InitializeComponent();
        _shell = shell;
        _operationService = operationService;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window window = new Window(_shell);
        _ = InitializeAsync();
        return window;
    }


    private async Task InitializeAsync()
    {
        await _shell.GoToAsync($"//calculator");
    }
}