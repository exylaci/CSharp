using System.Collections.ObjectModel;

namespace GITdemoMAUI.Models;

public class WorkItemRepository : IWorkItemRepository
//Az adattároló interfész megvalósítása
{
    public ObservableCollection<WorkItem> Items { get; } = new ObservableCollection<WorkItem>
    {
        //Csak hogy legyen benne adat, amit megjeleníthet
        new WorkItem("1", "MAUI Layoutok", "szertjük a layoutokat", WorkItemStatus.InProgress),
        new WorkItem("2", "Stílusok", "Stílusok használata", WorkItemStatus.Done),
        new WorkItem("3", "Lista és itemei", "Lista általában observable colléectionban", WorkItemStatus.Todo)
    };

    public void Add(WorkItem item)
    {
        Items.Add(item);
    }

    public WorkItem? FindById(string? id) => Items.FirstOrDefault(x => x.Id == id);

    public void Remove(WorkItem item)
    {
        Items.Remove(item);
    }

    public void Update(WorkItem item)
    {
        WorkItem? exitingItem = FindById(item.Id);
        if (exitingItem is null)
        {
            return;
        }

        Items[Items.IndexOf(exitingItem)] = item;
    }
}