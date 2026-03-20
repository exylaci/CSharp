using System.Windows.Input;

namespace GITdemoMAUI.Infrastructure;

public sealed class RelayCommandT<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    public RelayCommandT(Action<T> execute, Func<T, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        if (parameter is null)
        {
            return typeof(T).IsValueType ? false : _canExecute?.Invoke((T)parameter!) ?? true;
            //A ! -lel jelezzük, hogy ugyan nullable a típusa, de itt most biztos, hogy nem null 
        }

        if (parameter is not T t) //Ha parameter típusa nem ugyanaz, mint a RelayCommand-é
        {
            return false;
        }

        return _canExecute?.Invoke(t) ?? true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is not T t)
        {
            return;
        }

        _execute(t);
    }

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}