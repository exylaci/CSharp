namespace MauiRetegekPelda.Services;

public class NavigationService : INavigationService
{
    //Előállítja az oldalt a dependeny-ből, átadja neki a DTO-t, és beteszi magát a navigation stack-be.

    private readonly IServiceProvider _services;
    //A szervizeket tároló attribútumok mindig private readonly-k
    private readonly ICurrentPageAccessor _pageAccessor;
    // Azért kell az ICurrentPageAccessor, hogy a szervízünk tudja, hogy pontosan melyik Page-hez tartozó Navigation stack-et használja.


    public NavigationService(IServiceProvider services, ICurrentPageAccessor pageAccessor)
    {
        //Amikor a Page megjelenik, akkor az OnApearing event-je be fogja állítani, hogy igen én vagyok ez az oldal, injectionnel a konstruktorban ezeket fogadjuk és be is állítunk. (Eltároljuk mind a kettőt saját attribútumban.)

        _services = services;
        _pageAccessor = pageAccessor;
    }

    public async Task NavigateToAsync<TPage>(object? parameter = null) where TPage : Page
    {
        TPage page = _services.GetRequiredService<TPage>();
        if (parameter is not null && page.BindingContext is INavigationParameterReceiver receiver)
        {
            //Ha a page.BindingContext képes paramétereket fogadni, akkor átadjuk a paraméter objektumot (DTO-t).
            receiver.ApplyNavigationParameter(parameter);
        }

        INavigation? navigation = _pageAccessor.CurrentPage?.Navigation
                                  ?? Shell.Current?.Navigation
                                  ?? Application.Current?.MainPage.Navigation; //Minden lehet null.

        if (navigation is null)
        {
            return;
        }

        await navigation.PushAsync(page);
        //Berakja magát a navigation stack-re
    }

    public async Task GoBackAsync()
    {
        INavigation? navigation = _pageAccessor.CurrentPage?.Navigation
                                  ?? Shell.Current?.Navigation
                                  ?? Application.Current?.MainPage.Navigation;

        if (navigation is null || navigation.NavigationStack.Count <= 1)
        {
            //Azt is meg kell nézni, hogy van e go back. Mert ha több goback van a navigation stackben, az olyan mint ha a go back nem működne. Hiába nyomkodja a vissza gombot, nem történik semmi. Ezért már nem is próbáljuk meg kiszedni a stack-ből a visszatérési helyet.
            return;
        }

        await navigation.PopAsync();
        //Ha pusholtunk mindent a navigation stack-re, akkor ott kell lennie, hogy hova kell visszatérni.
        //Ha üres a stack, az nem baj, nem okoz hibát 0 elemű stack-ből Pop-olni.
    }
}