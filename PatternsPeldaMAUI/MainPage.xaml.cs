using PatternsPeldaMAUI.ViewModels;

namespace PatternsPeldaMAUI;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}