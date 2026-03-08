using System.Collections.ObjectModel;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Pages;
using GITdemoMAUI.Services;

namespace GITdemoMAUI.ViewModels;

public class WorkItemsViewModel : BaseViewModel
{
    public ObservableCollection<WorkItem> Items { get; }

    private readonly INavigationService _navigation;

    public AsyncRelayCommand<WorkItem> OpenItemCommand { get; } //Ebben a  gereikus Async OpenItemCommand-ban adjuk át a WorkItem-et


    public WorkItemsViewModel(INavigationService navigation, IWorkItemRepository repository)
        //Kostruktorban kapja meg a navigációt
    {
        _navigation = navigation; //későbbi navigációhoz kell letárolni
        Title = "Munkák";

        Items = repository.Items;

        OpenItemCommand = new AsyncRelayCommand<WorkItem>(OpenItemAsync); //A kiválasztottat átadva 
    }

    private async Task OpenItemAsync(WorkItem? selected) //Ezt a selected elemet választották ki
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
        await Shell.Current.GoToAsync(nameof(AddNewWorkItemPage));
    }
}