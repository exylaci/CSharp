using System.Collections.ObjectModel;
using GITdemoMAUI.Models;

namespace GITdemoMAUI.Services;

public interface IWorkItemStore
{
    ObservableCollection<WorkItem> Items { get; } //Ebben tároljuk az adatokat (workitem-eket)
    // void Add(WorkItem item);
    // WorkItem? FindById(string? id); //nullable, mert null ha nem talált
    // void Remove(WorkItem item);
    // bool RemoveById(string id);
    // void Update(WorkItem item);

    Task EnsureLoadedAsync(); //Biztosan be van-e töltve (van-e kapcsolat) az adatbázissal
    Task ReloadAsync(); //Frissitéshez az adatok újbóli betöltése
    Task AddAsync(WorkItem item); //Új eleme hozzáadása
    Task UpdateAsync(WorkItem item);
    Task<WorkItem?> FindByIdAsync(string id);
    Task<bool> RemoveByIdAsync(string id);
}