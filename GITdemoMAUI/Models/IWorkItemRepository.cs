using System.Collections.ObjectModel;

namespace GITdemoMAUI.Models;

public interface IWorkItemRepository
{
    ObservableCollection<WorkItem> Items { get; }
    void Add(WorkItem item);
    void Remove(WorkItem item);
}