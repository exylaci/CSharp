namespace MauiRetegekPelda.Services;

public interface INavigationService
//Az interfészben szabjuk meg, hogy a ViewModel hogyan kérhet navigációt anélkül, hogy tudná, hogy a navigáció pontosan hogyan valósul meg.
{
    Task NavigateToAsync<TPage>(object? parameter = null) where TPage : Page;
    // A Shell-es navigácio-hoz kell egy NavigateToAsync
    // where: A <TPage> ugyanúgy generikus, csak jelezzók, hogy valamilyen Page típusú generikus
    // Lehetne csak simán <T> id, de a Page korlátosság miatt írunk <TPage>-t. 

    Task GoBackAsync();
    //Vissza is kellhet tudni navigálni egy Page-ről. 
}