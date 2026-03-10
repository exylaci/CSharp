using System.Windows.Input;

namespace GITdemoMAUI.Infrastructure;

public class AsyncRelayCommand : ICommand   //Ezeket kötögetjük be a UI
{
    private readonly Func<Task> _executeAsync;  //futtatásra kell
    private readonly Func<bool>? _canExecute;   //futtatási feltétel ellenőrzésre (nem feltétlen van, ezért nullable)
    private bool _isExecuting; //Mivel async, kell tudni, hogy éppen fut-e

    public AsyncRelayCommand(Func<Task> executeAsync, Func<bool>? canExecute = null)
    {
        _executeAsync = executeAsync;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;   //Ez veszi észre ha megváltozik a command futtatás engedélyezése


    public bool CanExecute(object? parameter)   //a kapott szabállyal eldönteti, hogy futtaható-e. (Lehet null, nem kap paraméterben szabályt)

    {
        if (_isExecuting)       //Ha már fut a command akkor viszatér false-szal
        {
            return false;
        }

        return _canExecute?.Invoke() ?? true;   //Ha nincs szabály adva (null), akkor true -> végrehajtható a Command.
    }

    public async void Execute(object? parameter)    //A konstruktor paraméterben kapott commandot végrehajtja
    {
        if (!CanExecute(parameter))
        {
            return;
        }

        try
        {
            _isExecuting = true;
            RaiseCanExecuteChanged();
            await _executeAsync();
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);   //ha kiváltódik a sendernek visszaadja a this oject-et

}

public class AsyncRelayCommand<T> : ICommand
{
    private readonly Func<T?, Task> _executeAsync;
    private readonly Func<T?, bool>? _canExecute;
    private bool _isExecuting;

    public AsyncRelayCommand(Func<T?, Task> executeAsync, Func<T?, bool>? canExecute = null)
    {
        _executeAsync = executeAsync;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        if (_isExecuting)
        {
            return false;
        }

        return _canExecute?.Invoke((T?)parameter) ?? true;
    }

    public async void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
        {
            return;
        }

        try
        {
            _isExecuting = true;
            RaiseCanExecuteChanged();
            await _executeAsync((T?)parameter);
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    private void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}