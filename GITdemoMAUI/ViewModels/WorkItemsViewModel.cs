using System.Collections.ObjectModel;
using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using GITdemoMAUI.Services;

namespace GITdemoMAUI.ViewModels;

public class WorkItemsViewModel : BaseViewModel
{
    private readonly INavigationService _navigation;
    
    public ObservableCollection<WorkItem> Items { get; } 

    
    public AsyncRelayCommand<WorkItem> OpenItemCommand { get; } //Ebben a  gereikus Async OpenItemCommand-ban adjuk át a WorkItem-et

    

    public WorkItemsViewModel(INavigationService navigation) //Kostruktorban kapja meg a navigációt
    {
        _navigation = navigation;       //későbbi navigációhoz kell letárolni
        Title = "Munkák";
        
        Items = new ObservableCollection<WorkItem>
        {
            new WorkItem("1", "MAUI Layoutok", "szertjük a layoutokat", WorkItemStatus.InProgress),
            new WorkItem("2", "Stílusok", "Stílusok használata", WorkItemStatus.InProgress),
            new WorkItem("3", "Lista és itemei", "Lista általában observable colléectionban", WorkItemStatus.InProgress)
        };

        OpenItemCommand = new AsyncRelayCommand<WorkItem>(OpenItemAsync);   //A kiválasztottat átadva 

    }

    private async Task OpenItemAsync(WorkItem? selected)    //Ezt a selected elemet választották ki
    {
        if (selected is null)                               //Mindig ellenőrizni kell null-ra
        {
            return;
        }
        
        await _navigation.GoToAsync(nameof(Pages.WorkItemDetailPage),new Dictionary<string, object>{{"WorkItem", selected}});
    }
}