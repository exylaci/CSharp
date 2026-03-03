namespace GITdemoMAUI.Infrastructure;

public abstract class BaseViewModel : ObservableObject
{
    private bool _isBusy;
    private string _title = string.Empty;

    public bool IsBusy
    {
        get => _isBusy;
        set => SetField(ref _isBusy, value);
    }

    public string Title
    {
        get => _title;
        set => SetField(ref _title, value);
    }
}