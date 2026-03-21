using System.Collections.ObjectModel;
using GITdemoMAUI.Models;

namespace GITdemoMAUI.Services;

public class InMemoryWorkItemStore : IWorkItemStore
//Az adattároló interfész megvalósítása
{
    public ObservableCollection<WorkItem> Items { get; } = new ObservableCollection<WorkItem>
    {
        //Csak hogy legyen benne adat, amit megjeleníthet
        new WorkItem("111", "MAUI Layoutok", "szertjük a layoutokat", WorkItemStatus.InProgress),
        new WorkItem("222", "Stílusok", "Stílusok használata", WorkItemStatus.Done),
        new WorkItem("333", "Lista és itemei", "Lista általában observable colléectionban", WorkItemStatus.Todo)
    };

    public Task EnsureLoadedAsync()
    {
        return Task.CompletedTask; //Mindig bent van a memóriában a kollekció, eleve ott tartjuk
    }

    public Task ReloadAsync()
    {
        return Task.CompletedTask; //Eleve a memóriában van a kollekciónk
    }

    public Task AddAsync(WorkItem item)
    {
        Items.Add(item);
        return Task.CompletedTask;
    }

    public Task<WorkItem?> FindByIdAsync(string? id)
        => Task.FromResult(Items.FirstOrDefault(i => i.Id == id));

    public Task<bool> RemoveByIdAsync(string id)
    {
        WorkItem? existing = FindByIdAsync(id).Result;
        if (existing is null)
        {
            return Task.FromResult(false);
        }

        Items.Remove(existing);
        return Task.FromResult(true);
    }

    public Task UpdateAsync(WorkItem item)
    {
        WorkItem? exitingItem = FindByIdAsync(item.Id).Result;
        if (exitingItem is null)
        {
            return Task.CompletedTask;
        }

        Items[Items.IndexOf(exitingItem)] = item;
        return Task.CompletedTask;
    }
}