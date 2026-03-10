namespace GITdemoMAUI.Infrastructure;

public abstract class BaseViewModel : ObservableObject
{
    private bool _isBusy;
    private string _pageTitle = string.Empty;

    public bool IsBusy
    {
        get => _isBusy;
        set => SetField(ref _isBusy, value);
    }

    public string PageTitle
    {
        get => _pageTitle;
        set => SetField(ref _pageTitle, value);
    }
}