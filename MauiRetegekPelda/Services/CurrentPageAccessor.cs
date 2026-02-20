namespace MauiRetegekPelda.Services;

public sealed class CurrentPageAccessor : ICurrentPageAccessor
{
    public Page? CurrentPage { get; set; }
    // hogy példányosítható legyen az interface
}