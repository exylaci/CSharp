using MauiRetegekPelda.Pages;

namespace MauiRetegekPelda;

public partial class AppShell : Shell
{
    private readonly IServiceProvider _service;

    public AppShell(IServiceProvider service)
    {
        InitializeComponent();
        _service = service;
        AddDependencyInversionFlyout();
        AddNavigationFlyout();
    }

    private void AddNavigationFlyout()
    {
        FlyoutItem flyoutItem = new FlyoutItem
        {
            Title = "XAML + ModelView + DependencyInversion + Navigation",
            Route = "modelview-navigation"
        };
        flyoutItem.Items.Add(new ShellContent
            {
                ContentTemplate = new DataTemplate(() => _service.GetRequiredService<ContactEditorNavigationPage>())
            }
        );
        Items.Add(flyoutItem);  // Ennek az "ablaknak" a felvétele a kollekcióhoz
    }

    private void AddDependencyInversionFlyout()
    {
        FlyoutItem flyoutItem = new FlyoutItem
        {
            Title = "XAML + ModelView + DependencyInversion",
            Route = "modelview-dependencyinversion",
        };

        flyoutItem.Items.Add(new ShellContent
        {
            ContentTemplate = new DataTemplate(() =>
                _service.GetRequiredService<ContactEditorModelViewDependencyInversionPage>())
        });
        Items.Add(flyoutItem);
    }
}