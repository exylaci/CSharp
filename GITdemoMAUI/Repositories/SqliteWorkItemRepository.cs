using GITdemoMAUI.Infrastructure;
using GITdemoMAUI.Models;
using SQLite;

namespace GITdemoMAUI.Repositories;

public class SqliteWorkItemRepository : IWorkItemRepository
{
    private SQLiteAsyncConnection db; //Adatbázishoz kapcsolódáshoz kell. Az adatbázis az alkalmazás indításakor elkészül a usernél helyben
    private readonly SemaphoreSlim initLock = new SemaphoreSlim(1, 1); //Amig az adatbázis inicializálása elkészül, vagy adat mozgás idelyére lockolni kell az adatbázishoz hozzáférést
    private bool initialized;

    public SqliteWorkItemRepository(IDbPathProvider dbPathProvider)
    {
        db = new SQLiteAsyncConnection(dbPathProvider.DbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache); //flag-ek az adatbázis használat módjáról
    }


    public async Task<IReadOnlyList<WorkItem>> GetAllAsync()
    {
        await EnsureInitailzedAsync();
        List<WorkItemRow> rows = await db.Table<WorkItemRow>()
            .OrderByDescending(x => x.UpdatedAtUnixMs)
            .ToListAsync();
        return rows.Select(ToDomain).ToList();
    }


    public async Task<WorkItem?> GetByIdAsync(string id)
    {
        await EnsureInitailzedAsync();
        WorkItemRow? row = await db.Table<WorkItemRow>()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        return row is null ? null : ToDomain(row);
    }

    public async Task UpsertAsync(WorkItem item)
    {
        await EnsureInitailzedAsync();
        WorkItemRow row = ToRow(item);
        await db.InsertOrReplaceAsync(row);
    }

    public async Task<bool> DeleteById(string id)
    {
        await EnsureInitailzedAsync();
        int rowAffected = await db.DeleteAsync<WorkItemRow>(id);
        return rowAffected > 0;
    }

    private async Task EnsureInitailzedAsync()
    {
        //Biztosan csak egy adatbázis legyen.
        if (initialized)
        {
            return; //Ha már fut, nem kell mégegyszer
        }

        await initLock.WaitAsync(); //lock-olás

        try
        {
            if (!initialized)
            {
                return;
            }

            await db.CreateTableAsync<WorkItemRow>();
            initialized = true;
        }
        finally
        {
            initLock.Release(); //Lefutott lockolás feloldható
        }
    }

    private static WorkItem ToDomain(WorkItemRow row)
    {
        DateTimeOffset updated = DateTimeOffset.FromUnixTimeMilliseconds(row.UpdatedAtUnixMs);
        return new WorkItem(
            row.Id,
            row.Title,
            row.Description,
            (WorkItemStatus)row.Status,
            updated);
    }

    private static WorkItemRow ToRow(WorkItem item)
    {
        return new WorkItemRow
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            Status = (int)item.Status,
            UpdatedAtUnixMs = item.UpdatedAt.ToUnixTimeMilliseconds()
        };
    }
}