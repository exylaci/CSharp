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
    
    public WorkItemDetailViewModel(INavigationService navigation, IWorkItemRepository repository)
    {
        _navigation = navigation;
        _repository = repository;
        Title = "Részletek";

        BackCommand = new AsyncRelayCommand(() => _navigation.GoBackAsync()); //Visszatérési hely beállítása
        EraseWorkItem = new AsyncRelayCommand(EraseItemAsync); //A kiválasztott elemet átadva 
    }

    private async Task EraseItemAsync() //Ezt a selected elemet választották ki
    {
        if (_item is null) //Mindig ellenőrizni kell null-ra
        {
            return;
        }
        _repository.Remove(_item);
        await _navigation.GoBackAsync();
        // new Dictionary<string, object> { { "WorkItem", selected } };
    }

    public void Receive(IDictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("WorkItem", out var obj) && obj is WorkItem item)
        {
            Item = item;
        }
    }
}