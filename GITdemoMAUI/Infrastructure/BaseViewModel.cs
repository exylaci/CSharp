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

    protected async Task RunBusyAsync(Func<Task> action) //Ezt a Taskot hívva, ez leellenőrzi, IsBusy-t hogy futtatható-e. És ha igen, akkor az akcióban megkapott feladatot futtatja. Így nem kell a programban mindenhol elleőrizgetni, hogy az IsBusy állapota alapján szabad-e futtatni.
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            await action();
        }
        finally
        {
            IsBusy = false;
        }
    }

    protected async Task RunBusyAsync(Func<Task> action, Func<Exception, Task> onError) //Ugyanaz mint a másik, csak hibakezeléssel.
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            IsBusy = true;
            await action();
        }
        catch (Exception ex)
        {
            await onError(ex);  //Hiba esetén futtattatja az onError paraméterben kapott Task-ot
        }
        finally
        {
            IsBusy = false;
        }
    }
}