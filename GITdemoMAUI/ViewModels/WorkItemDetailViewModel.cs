using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Services;

namespace GITdemoMAUI.ViewModels;

public sealed class WorkItemDetailViewModel : BaseViewModel, INavigationParameterReceiver
{
    private readonly INavigationService _navigation;
    private WorkItem? _item;

    public AsyncRelayCommand BackCommand { get; }

    public WorkItem? Item
    {
        get => _item;
        private set => SetField(ref _item, value);
    }

    public WorkItemDetailViewModel(INavigationService navigation)
    {
        _navigation = navigation;
        Title = "Részletek";

        BackCommand = new AsyncRelayCommand(() => _navigation.GoBackAsync()); //Visszatérési hely beállítása
    }

    public void Receive(IDictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("WorkItem", out var obj) && obj is WorkItem item)
        {
            Item = item;
        }
    }
}