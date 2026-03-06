using System.Collections.ObjectModel;

namespace GITdemoMAUI.Models;

public class WorkItemRepository : IWorkItemRepository
{
    public ObservableCollection<WorkItem> Items { get; } = new ObservableCollection<WorkItem>
    {
        new WorkItem("1", "MAUI Layoutok", "szertjük a layoutokat", WorkItemStatus.InProgress),
        new WorkItem("2", "Stílusok", "Stílusok használata", WorkItemStatus.Done),
        new WorkItem("3", "Lista és itemei", "Lista általában observable colléectionban", WorkItemStatus.Todo)
    };

    public void Add(WorkItem item)
    {
        Items.Add(item);
    }

    public void Remove(WorkItem item)
    {
        Items.Remove(item);
    }
}