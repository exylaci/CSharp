using System.Collections.ObjectModel;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Pages;
using GITdemoMAUI.Services;

namespace GITdemoMAUI.ViewModels;

public class WorkItemsViewModel : BaseViewModel
{
    private readonly INavigationService _navigation;    //A későbbi navigáció tárolására
    public ObservableCollection<WorkItem> Items { get; }    //Az adatokat tároló kollekcióra hivatkozás tárolására


    public AsyncRelayCommand<WorkItem> OpenItemCommand { get; } //Ebben a gereikus async command-ban adjuk át a WorkItem-et
    public AsyncRelayCommand AddNewItemCommand { get; } //Ebben az Async OpenItemCommand-ban adjuk át a WorkItem-et


    public WorkItemsViewModel(INavigationService navigation, IWorkItemRepository repository)
        //Kostruktor paraméterében kapja meg a navigációt, és az adat tároló osztályra hivatkozást
    {
        _navigation = navigation; //későbbi navigációhoz kell letárolni a DI-ben fogadott navigációt
        Items = repository.Items; //Mivel csak itt használjuk egyszer, nem tároljuk el a repository paramétert

        PageTitle = "Feladatok";    //Az oldal fejlécébe rakjuk majd be (jelenítjük meg), mint az oldal neve

        OpenItemCommand = new AsyncRelayCommand<WorkItem>(OpenItemAsync); //A lista egy elemére kattintva ugrik ide. "Jön vele" a CommandParameter="{Binding .} -gal hozzákötött <WorkItem> típusú aktuális eleme a listának. Ezt adja tovább a meghívott OpenItemAsync függvénynek. 
        AddNewItemCommand = new AsyncRelayCommand(AddNewItemAsync); //A [+] gomb megnyomására ide ugrik. Új elem hozzáadása esetén (mivel nem kell aktuálisan kiválasztott listaelemmel foglalkozni) az paraméter nélküli AsyncRelayCommandon keresztűl hívjuk az AddNewItemAsync függvényünket. 
    }

    private Task AddNewItemAsync()  
    {
        return _navigation.GoToAsync(nameof(Pages.WorkItemEditorPage));
    }

    private async Task OpenItemAsync(WorkItem? selected) //Ezt a selected elemet választották ki a listából
    {
        if (selected is null) //Mindig ellenőrizni kell null-ra
        {
            return;
        }

        await _navigation.GoToAsync(nameof(Pages.WorkItemDetailPage),
            new Dictionary<string, object> { { "WorkItem", selected } });
    }

    private async Task GoToAddNewItem()
    {
        await Shell.Current.GoToAsync(nameof(WorkItemEditorPage));
    }
}