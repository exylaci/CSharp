namespace GITdemoMAUI.Models;

public sealed class WorkItem
{
    public string Id { get; }
    public string Title { get; }
    public string Description { get; }
    public WorkItemStatus Status { get; }
    public DateTimeOffset UpdatedAt { get; }


    public WorkItem(string id, string title, string description, WorkItemStatus status)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
        UpdatedAt = DateTimeOffset.Now;
    }
}

public enum WorkItemStatus
{
    Todo = 0,
    InProgress = 1,
    Done = 2
}