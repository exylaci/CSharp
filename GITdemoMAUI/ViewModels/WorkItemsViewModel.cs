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
    private readonly IDialogService _dialog;

    private WorkItem? _selectedItem;
    private bool _isRefreshing;
    private bool _isSwipping;
    public ObservableCollection<WorkItem> Items { get; } //Az adatokat tároló kollekcióra hivatkozás tárolására

    public AsyncRelayCommand<WorkItem> OpenItemCommand { get; } //Ebben a gereikus async command-ban adjuk át a kiválasztott WorkItem-et
    public AsyncRelayCommand<WorkItem> DeleteItemCommand { get; } //Ebben a gereikus async command-ban adjuk át a törlendő WorkItem-et
    public AsyncRelayCommand<WorkItem> ModifyItemCommand { get; } //Ebben a gereikus async command-ban adjuk át a módosítandó WorkItem-et
    public AsyncRelayCommand AddNewItemCommand { get; } //Ezzel az Async AddNewItemCommand-dal lehet új workitem létrehozására "ugrani"
    public AsyncRelayCommand RefreshCommand { get; }


    public WorkItem? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (SetField(ref _selectedItem, value) && _selectedItem is not null)
            {
                WorkItem picked = _selectedItem;
                SelectedItem = null;
                OpenItemCommand?.Execute(picked);
            }
        }
    }

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetField(ref _isRefreshing, value);
    }

    public bool IsSwipping
    {
        get => _isSwipping;
        set => SetField(ref _isSwipping, value);
    }


    public WorkItemsViewModel(INavigationService navigation, IWorkItemRepository repository, IDialogService dialogDialog)
        //Kostruktor paraméterében kapja meg a navigációt, és az adat tároló osztályra hivatkozást
    {
        _navigation = navigation; //későbbi navigációhoz kell letárolni a DI-ben fogadott navigációt
        _repository = repository;
        _dialog = dialogDialog;


        Items = _repository.Items;

        PageTitle = "Feladatok"; //Az oldal fejlécébe rakjuk majd be (jelenítjük meg), mint az oldal neve

        OpenItemCommand = new AsyncRelayCommand<WorkItem>(OpenItemAsync, item => item is not null); //A lista egy elemére kattintva ugrik ide. "Jön vele" a CommandParameter="{Binding .} -gal hozzákötött <WorkItem> típusú aktuális eleme a listának. Ezt adja tovább a meghívott OpenItemAsync függvénynek. 
        //item => item is not null : Futtatási feltétel lambda függvény, hogy nem lehet null
        DeleteItemCommand = new AsyncRelayCommand<WorkItem>(DeleteItemAsync, item => item is not null);
        ModifyItemCommand = new AsyncRelayCommand<WorkItem>(ModifyItemAsync, item => item is not null);
        AddNewItemCommand = new AsyncRelayCommand(AddNewItemAsync); //A [+] gomb megnyomására ide ugrik. Új elem hozzáadása esetén (mivel nem kell aktuálisan kiválasztott listaelemmel foglalkozni) az paraméter nélküli AsyncRelayCommandon keresztűl hívjuk az AddNewItemAsync függvényünket. 
        RefreshCommand = new AsyncRelayCommand(RefreshAsync);
    }


    private async Task RefreshAsync()
    {
        if (IsRefreshing)
        {
            return; //Amíg az előző frissítés nem futott le, nem fordulunk újra a backend-hez
        }

        try
        {
            IsRefreshing = true;
            await Task.Delay(400);  //Csak szimuláljuk, mint ha várakozna egy távoli adatbázishoz csatlakoásra és időbe tellik mire megkapja onnan a lekérdezett adatot
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    private Task ModifyItemAsync(WorkItem selected)
    {
        return _navigation.GoToAsync(nameof(Pages.WorkItemEditorPage), new Dictionary<string, object>
        {
            { "Mode", "Edit" },         //szerkesztés üzemmódban akarjuk használni az EditorPage-et; ezt adjuk át a Mode attribútumnak
            { "WorkItem", selected }
        });
    }

    private async Task DeleteItemAsync(WorkItem selected)
    {
        if (!await _dialog.ShowConfirmationRequestAsync(//parameter:adat <--Ilyen formátumban is meg lehet adni az átadandó paramétereket, így nem keverednek össze.
                title: "Feladat törlése a listából",
                message: $"Biztosan törölni szeretné ezt?\n{selected.Title}",
                accept: "Törlés") )
        {
            return; //Ha mégsem akar törölni, kilépünk.
        }

        await RunBusyAsync(() =>    //Ez kezeli helyettünk az IsBusy-t. Ami által nem tudja a felhasználó érdemben nyomogatni a gombot. (Előtte tekergeti a nyalókát.)
            {
                if (!_repository.RemoveById(selected.Id)) //elem törlése a kollekcióból
                {   //Nem sikrült törölni.
                    throw new InvalidOperationException("Nem található az elem, lehet már törölve lett.");
                }

                return Task.CompletedTask;
            },
            ex => _dialog.ShowErrorAsync(ex.Message)    //Amit a sikertelen törlés esetén pl. feljebb dobtunk kivételt, azt ezzel a lambda kifejezéses névtelen metódussal kezeltetjük le a RunBusyAsync metódusban.  (De minden más egyéb esetlegesen bekövetkező hiba esetet is ez kezeli le.)
        );
        await _navigation.GoBackAsync(); //visszatérés az előző oldalra
    }

    private Task AddNewItemAsync()
    {
        return _navigation.GoToAsync(nameof(Pages.WorkItemEditorPage), new Dictionary<string, object> { { "Mode", "Create" } });
    }

    private async Task OpenItemAsync(WorkItem selected) //Ezt a selected elemet választották ki a listából
    {
        await _navigation.GoToAsync(nameof(Pages.WorkItemDetailPage),
            new Dictionary<string, object> { { "WorkItem", selected } });
    }

    // private async Task GoToAddNewItem()
    // {
    //     await Shell.Current.GoToAsync(nameof(WorkItemEditorPage));
    // }
}