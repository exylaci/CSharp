using GITdemoMAUI.Models;

namespace GITdemoMAUI.Repositories;

public interface IWorkItemRepository
{   //Az alap adatbázis műveletek interfésze
    Task<IReadOnlyList<WorkItem>> GetAllAsync();
    Task<WorkItem?> GetByIdAsync(string id);
    Task UpsertAsync(WorkItem item);                //Update és Insert-hez is.
    Task<bool> DeleteById(string id);
}

