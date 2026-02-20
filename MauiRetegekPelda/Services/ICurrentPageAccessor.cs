namespace MauiRetegekPelda.Services;

public interface ICurrentPageAccessor
{
    Page? CurrentPage { get; set; }
    // Ez a "pointer" mutat az aktív Page-re.
}