namespace ASPdotNETticketAPI.Dtos.Common;

public class PagedResultDto<T>
//Nem csak az osztály adatait adja vissza, hanem a lapozáshoz szükséges meta információkat is (oldalak száma, van-e előző/következő oldal, stb
{
    public List<T> Items { get; set; } = [];
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}