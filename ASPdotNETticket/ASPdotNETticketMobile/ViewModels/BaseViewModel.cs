using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ASPdotNETticketMobile.ViewModels;

public class BaseViewModel : INotifyPropertyChanged //Itt van minden olyan ismétlődő dolog ami az össze oldalon van
{
    private bool isBusy;
    private string errorMessage = string.Empty;
    private string title = string.Empty;

    public bool IsBusy     //attribútumokat kijelölve generate property, setfield-et használva legenerálja a getter/settereket a Rider 
    {
        get => isBusy;
        set => SetField(ref isBusy, value);
    }

    public string ErrorMessage
    {
        get => errorMessage;
        set => SetField(ref errorMessage, value);
    }

    public string Title
    {
        get => title;
        set => SetField(ref title, value);
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