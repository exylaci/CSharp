namespace GITdemoMAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Pages.WorkItemDetailPage), typeof(Pages.WorkItemDetailPage));
    }
}