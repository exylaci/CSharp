using System.Collections.ObjectModel;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Pages;
using GITdemoMAUI.Services;

namespace GITdemoMAUI.ViewModels;

public class WorkItemsViewModel : BaseViewModel
{
    private readonly INavigationService _navigation; //A későbbi navigáció tárolására
    private readonly IWorkItemRepository _repository; //Az adatok tárolásához
    private readonly IDialogService _service;

    public ObservableCollection<WorkItem> Items { get; } //Az adatokat tároló kollekcióra hivatkozás tárolására


    public AsyncRelayCommand<WorkItem> OpenItemCommand { get; } //Ebben a gereikus async command-ban adjuk át a kiválasztott WorkItem-et
    public AsyncRelayCommand<WorkItem> DeleteItemCommand { get; } //Ebben a gereikus async command-ban adjuk át a törlendő WorkItem-et
    public AsyncRelayCommand<WorkItem> ModifyItemCommand { get; } //Ebben a gereikus async command-ban adjuk át a módosítandó WorkItem-et
    public AsyncRelayCommand AddNewItemCommand { get; } //Ebben az Async OpenItemCommand-ban adjuk át a WorkItem-et


    public WorkItemsViewModel(INavigationService navigation, IWorkItemRepository repository, IDialogService dialogService)
        //Kostruktor paraméterében kapja meg a navigációt, és az adat tároló osztályra hivatkozást
    {
        _navigation = navigation; //későbbi navigációhoz kell letárolni a DI-ben fogadott navigációt
        _repository = repository;
        _service = dialogService;

        Items = _repository.Items;

        PageTitle = "Feladatok"; //Az oldal fejlécébe rakjuk majd be (jelenítjük meg), mint az oldal neve

        OpenItemCommand = new AsyncRelayCommand<WorkItem>(OpenItemAsync); //A lista egy elemére kattintva ugrik ide. "Jön vele" a CommandParameter="{Binding .} -gal hozzákötött <WorkItem> típusú aktuális eleme a listának. Ezt adja tovább a meghívott OpenItemAsync függvénynek. 
        DeleteItemCommand = new AsyncRelayCommand<WorkItem>(DeleteItemAsync);
        ModifyItemCommand = new AsyncRelayCommand<WorkItem>(ModifyItemAsync);
        AddNewItemCommand = new AsyncRelayCommand(AddNewItemAsync); //A [+] gomb megnyomására ide ugrik. Új elem hozzáadása esetén (mivel nem kell aktuálisan kiválasztott listaelemmel foglalkozni) az paraméter nélküli AsyncRelayCommandon keresztűl hívjuk az AddNewItemAsync függvényünket. 
    }

    private Task ModifyItemAsync(WorkItem? selected)
    {
        return _navigation.GoToAsync(nameof(Pages.WorkItemEditorPage), new Dictionary<string, object>
        {
            { "Mode", "Edit" }, 
            { "WorkItem", selected }
        });
    }

    private async Task DeleteItemAsync(WorkItem? selected)
    {
        if (selected is null) //Mindig ellenőrizni kell null-ra
        {
            return;
        }

        if (await _service.ShowConfirmationRequestAsync("Feladat törlése a listából", "Biztosan törölni szeretné?", "Igen", "Nem"))
        {
            _repository.RemoveById(selected.Id); //elem törlése a kollekcióból
            await _navigation.GoBackAsync(); //visszatérés az előző oldalra
        }
    }

    private Task AddNewItemAsync()
    {
        return _navigation.GoToAsync(nameof(Pages.WorkItemEditorPage), new Dictionary<string, object> { { "Mode", "Create" } });
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