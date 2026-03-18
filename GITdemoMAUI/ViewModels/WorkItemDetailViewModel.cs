using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Services;

namespace GITdemoMAUI.ViewModels;

public sealed class WorkItemDetailViewModel : BaseViewModel, INavigationParameterReceiver
{
    private readonly INavigationService _navigation;
    private readonly IWorkItemRepository _repository;
    private readonly IDialogService _dialog;

    private WorkItem? item;

    public AsyncRelayCommand BackCommand { get; }
    public AsyncRelayCommand EraseWorkItemCommand { get; }
    public AsyncRelayCommand ModifyWorkItemCommand { get; }


    public WorkItem? Item
    {
        get => item;
        private set
        {
            if (SetField(ref item, value))
            {
                ModifyWorkItemCommand.RaiseCanExecuteChanged();
                EraseWorkItemCommand.RaiseCanExecuteChanged();
            }
        }
    }


    public WorkItemDetailViewModel(INavigationService navigation, IWorkItemRepository repository, IDialogService dialog)
    {
        _navigation = navigation;
        _repository = repository;
        _dialog = dialog;

        PageTitle = "Részletek";

        BackCommand = new AsyncRelayCommand(() => _navigation.GoBackAsync()); //Visszatérési helyre ugrás hozzárendelése a command-hoz
        EraseWorkItemCommand = new AsyncRelayCommand(EraseItemAsync, () => Item is not null); //EraseItemAsync metódus hozzárendelése a command-hoz
        ModifyWorkItemCommand = new AsyncRelayCommand(ModifyItemAsync, () => Item is not null); //EditItemAsync metódus hozzárendelése a command-hoz
    }

    public void Refresh()
    {
        if (Item is null || Item.Id is null)
        {
            return;
        }

        //Csak akkor van értelme a Page-et frissíteni, ha van workitem-ben adat, vagyis ha ID nem null 
        Item = _repository.FindById(Item.Id);
    }

    private Task ModifyItemAsync()
    {
        if (Item is null) //Mindig ellenőrizni kell null-ra
        {
            return Task.CompletedTask; //Ha nem async akkor Task.Completed-del tudunk visszatérni
        }

        return _navigation.GoToAsync(nameof(Pages.WorkItemEditorPage), new Dictionary<string, object>
        {
            { "Mode", "Edit" }, //hogy tudja az editorPage melyik funkciót kell csinálnia
            { "WorkItem", Item } //átadjuk a workitem elemet is neki
        });
    }

    private async Task EraseItemAsync()
        //Akkor kell async ha await van
    {
        if (item is null) //Mindig ellenőrizni kell null-ra
        {
            return;
        }

        if (await _dialog.ShowConfirmationRequestAsync(
                title: "Feladat törlése a listából",
                message: "Biztosan törölni szeretné?",
                accept: "Igen",
                cancel: "Nem") == false)
        {
            return;
        }

        try
        {
            IsBusy = true;
            if (_repository.RemoveById(item.Id) == false) //elem törlése a kollekcióból
            {
                await _dialog.ShowErrorAsync("Nem található. Lehet, már törölve lett.");
                return;
            }

            await _navigation.GoBackAsync(); //sikeres törlés után visszatérés az előző oldalra
        }
        catch (Exception e)
        {
            await _dialog.ShowErrorAsync($"Váratlan hiba történt törlés közben:\n{e.Message}");
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void Receive(IDictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("WorkItem", out var obj) && obj is WorkItem workItem)
            //Mindig TryGetValue(-val, próbáljuk meg elérni a kapott paramétert, mert nem biztos, hogy stimmel a típusa
        {
            //ha WorkItem típusú a kapott paraméter
            Item = workItem; //eltároljuk a kapott workitem-et
        }
    }
}