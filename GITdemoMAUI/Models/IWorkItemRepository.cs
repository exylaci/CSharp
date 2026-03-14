using System.Collections.ObjectModel;

namespace GITdemoMAUI.Models;

public interface IWorkItemRepository
{
    ObservableCollection<WorkItem> Items { get; } //Ebben tároljuk az adatokat (workitem-eket)
    void Add(WorkItem item);
    WorkItem? FindById(string? id); //nullable, mert null ha nem talált
    void Remove(WorkItem item);
    bool RemoveById(string id);
    void Update(WorkItem item);
}