using System.Collections.ObjectModel;

namespace GITdemoMAUI.Models;

public interface IWorkItemRepository
{
    ObservableCollection<WorkItem> Items { get; } //Ebben tároljuk az adatokat (workitem-eket)
    void Add(WorkItem item);
    WorkItem? FindById(String id); //nullable, mert null ha nem talált
    void Remove(WorkItem item);
}