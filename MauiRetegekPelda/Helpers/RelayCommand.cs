using System.Windows.Input;

namespace MauiRetegekPelda.Helpers;

public sealed class RelayCommand : ICommand //Riderrel implementálva minden prperty-jét
{
// Ez a segéd osztály implementálja az ICommand-ot,
// Execute: mit csináljon,
// CanExecute: szabad-e most csinálnia (Kapcsolgatható, hogy végrehajtsa-e, vagy sem.)
// lezárva (sealed)

    private readonly Action _execute;
    //Mit csináljon

    private readonly Func<bool>? _canExecute;
    //Szabad-e csinálnia. Azért nullable, mert nem minden esetben kell szabály.

    public RelayCommand(Action execute, Func<bool>? canExecute = null) //sima paraméterezett konstruktor
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;
    //Ha nincs canExecute (paraméter nélkül hívódik), akkoris visszatér true-val.
    // Azért kell a true, hogy minden esetben kattintható legyen a [Save] gomb.

    public void Execute(object? parameter) => _execute();
    //Csak simán végrehajtja

    public event EventHandler? CanExecuteChanged;
    //ha véltozott valami, akkor szólunk a UI-nak, hogy pl. nézze meg újra, kattintható-e a gomb

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    //Kézzel is lehet végrehajtatni. Empty: Mert nincs ezt kiváltó esemény.
}

//A fenti (paraméter nélküli) generikus paraméterezett változata:
public sealed class RelayCommand<T> : ICommand //Implementáljuk minden prperty-jét
{
    private readonly Action<T?> _execute;

    private readonly Func<T?, bool>? _canExecute;

    public RelayCommand(Action<T?> execute, Func<T?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke((T?)parameter) ?? true;
    //Valamilyen, akármilyen paraméterrel hívódik, akkor azt a paraméter generikusra kasztolva adjuk át az invoke-nak

    public void Execute(object? parameter) => _execute((T?)parameter);

    public event EventHandler? CanExecuteChanged;

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}