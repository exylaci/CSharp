using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ASPdotNETcalculator.MAUI.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    private bool _isBusy;
    private string _errorMessage = string.Empty;
    private string _pageTitle = string.Empty;

    public bool IsBusy
    {
        get => _isBusy;
        set => SetField(ref _isBusy, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetField(ref _errorMessage, value);
    }

    public string PageTitle
    {
        get => _pageTitle;
        set => SetField(ref _pageTitle, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}