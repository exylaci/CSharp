using System.Windows.Input;

namespace GITdemoMAUI.Infrastructure;

public class AsyncRelayCommand<T> : ICommand //Ezeket kötögetjük be a UI
{
    private readonly Func<T?, Task> _executeAsync; //futtatásra kell
    private readonly Func<T?, bool>? _canExecute; //futtatási feltétel ellenőrzésre (nem feltétlen van, ezért nullable)
    private bool _isExecuting; //Mivel async, kell tudni, hogy éppen fut-e
    
    public event EventHandler? CanExecuteChanged; //Ez veszi észre ha megváltozik a command futtatás engedélyezése

    
    public AsyncRelayCommand(Func<T?, Task> executeAsync, Func<T?, bool>? canExecute = null)
    {
        _executeAsync = executeAsync;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) //a kapott szabállyal eldönteti, hogy futtaható-e. (Lehet null, nem kap paraméterben szabályt)

    {
        if (_isExecuting) //Ha már fut a command akkor viszatér false-szal, nem futtatható egyszerre 2 példányban
        {
            return false;
        }

        if (parameter is null)
        {
            return typeof(T).IsValueType ? false : _canExecute?.Invoke((T)parameter!) ?? true;
            //A ! -lel jelezzük, hogy ugyan nullable a típusa, de itt most biztos, hogy nem null 
        }

        if (parameter is not T t) //Ha parameter típusa nem ugyanaz, mint a RelayCommand-é
        {
            return false;
        }

        return _canExecute?.Invoke(t) ?? true; //Ha nincs szabály adva (null), akkor true -> végrehajtható a Command.
    }

    public async void Execute(object? parameter) //A konstruktor paraméterben kapott commandot végrehajtja
    {
        if (!CanExecute(parameter))
        {
            return;
        }

        try
        {
            _isExecuting = true;
            RaiseCanExecuteChanged();
            await _executeAsync((T)parameter);
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty); //ha kiváltódik a sendernek visszaadja a this oject-et
}