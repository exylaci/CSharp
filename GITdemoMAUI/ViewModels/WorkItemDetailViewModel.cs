using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Services;

namespace GITdemoMAUI.ViewModels;

public sealed class WorkItemDetailViewModel : BaseViewModel, INavigationParameterReceiver
{
    private readonly INavigationService _navigation;
    private WorkItem? _item;

    public AsyncRelayCommand BackCommand { get; }
    public AsyncRelayCommand EraseWorkItem { get; }

    public WorkItem? Item
    {
        get => _item;
        private set => SetField(ref _item, value);
    }

    private readonly IWorkItemRepository _repository;
    private readonly IDialogService _service;

    public WorkItemDetailViewModel(INavigationService navigation, IWorkItemRepository repository,
        IDialogService dialogService)
    {
        _navigation = navigation;
        _repository = repository;
        _service = dialogService;
        
        Title = "Részletek";

        BackCommand =
            new AsyncRelayCommand(() =>
                _navigation.GoBackAsync()); //Visszatérési helyre ugrás hozzárendelése a command-hoz
        EraseWorkItem = new AsyncRelayCommand(EraseItemAsync); //EraseItemAsync metódus hozzárendelése a command-hoz
    }

    private async Task EraseItemAsync()
    {
        if (_item is null) //Mindig ellenőrizni kell null-ra
        {
            return;
        }

        //TODO: rákérdezni, hogy biztos-e benne


        if (await _service.ShowConfirmationRequestAsync("Feladat törlése a listából", "Biztosan törölni szeretné?",
                "Igen","Nem"))
        {
            _repository.Remove(_item); //elem törlése a kollekcióból
            await _navigation.GoBackAsync(); //visszatérés az előző oldalra
        }
    }

    public void Receive(IDictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("WorkItem", out var obj) && obj is WorkItem item)
        {
            Item = item;
        }
    }
}