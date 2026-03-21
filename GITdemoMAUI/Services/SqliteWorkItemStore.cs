using System.Collections.ObjectModel;
using GITdemoMAUI.Models;
using GITdemoMAUI.Repositories;

namespace GITdemoMAUI.Services;

public class SqliteWorkItemStore : IWorkItemStore
{
    private readonly IWorkItemRepository repo;
    private readonly SemaphoreSlim loadLock = new SemaphoreSlim(1, 1);
    private bool loaded;
    public ObservableCollection<WorkItem> Items { get; }


    public SqliteWorkItemStore(IWorkItemRepository repo)
    {
        this.repo = repo;
        Items = new ObservableCollection<WorkItem>();
    }


    public async Task EnsureLoadedAsync()
    {
        if (loaded)
        {
            return;
        }

        await loadLock.WaitAsync();

        try
        {
            if (loaded)
            {
                return;
            }

            await ReloadInternalAsync();
            loaded = true;
        }
        finally
        {
            loadLock.Release();
        }
    }

    private async Task ReloadInternalAsync()
    {
        IReadOnlyList<WorkItem> all = await repo.GetAllAsync();
        Items.Clear();
        foreach (WorkItem item in all)
        {
            Items.Add(item);
        }
    }

    public async Task ReloadAsync()
    {
        await EnsureLoadedAsync();
        await ReloadInternalAsync();
    }

    public async Task AddAsync(WorkItem item)
    {
        await EnsureLoadedAsync();
        await repo.UpsertAsync(item);
        Items.Insert(0, item);
    }

    public async Task UpdateAsync(WorkItem item)
    {
        await EnsureLoadedAsync();
        await repo.UpsertAsync(item);

        WorkItem? existing = Items.FirstOrDefault(i => i.Id == item.Id);

        if (existing is null)
        {
            Items.Insert(0, item);
            return;
        }

        int index = Items.IndexOf(existing);
        Items[index] = item;
    }

    public async Task<WorkItem?> FindByIdAsync(string id)
    {
        await EnsureLoadedAsync();
        return await repo.GetByIdAsync(id);
    }

    public async Task<bool> RemoveByIdAsync(string id)
    {
        await EnsureLoadedAsync();
        bool deleted = await repo.DeleteById(id);
        if (!deleted)
        {
            return false;
        }

        WorkItem? existing = Items.FirstOrDefault(x => x.Id == id);
        if (existing is not null)
        {
            Items.Remove(existing);
        }

        return true;
    }
}