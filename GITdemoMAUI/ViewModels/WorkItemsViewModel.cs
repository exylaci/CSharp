using System.Collections.ObjectModel;
using GITdemoMAUI.Models;

namespace GITdemoMAUI.ViewModels;

public class WorkItemsViewModel
{
    public ObservableCollection<WorkItem> Items { get; }

    public WorkItem? SelectedItem { get; set; }

    public WorkItemsViewModel()
    {
        Items = new ObservableCollection<WorkItem>
        {
            new WorkItem("1", "MAUI Layoutok", "szertjük a layoutokat", WorkItemStatus.InProgress),
            new WorkItem("2", "Stílusok", "Stílusok használata", WorkItemStatus.Done),
            new WorkItem("3", "Lista és itemei", "Lista általában observable colléectionban", WorkItemStatus.Todo)
        };
    }
}