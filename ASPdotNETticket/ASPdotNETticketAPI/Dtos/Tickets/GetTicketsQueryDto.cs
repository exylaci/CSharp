using System.ComponentModel.DataAnnotations;
using ASPdotNETticketAPI.Enums;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class GetTicketsQueryDto
{
    public string? SearchTerm { get; set; }
    public TicketStatus? Status { get; set; }
    public TicketPriority? Priority { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A kategória azonosító csak pozitív egéész szám lehet")]
    public int? CategoryId { get; set; }

    public string? SortBy { get; set; } = "createdAt";
    public string? SortDirection { get; set; } = "desc";

    [Range(1, int.MaxValue, ErrorMessage = "Az oldal szám pozitív egész szám kell legyen.")]
    public int PageNumber { get; set; } = 1;

    [Range(1, 100, ErrorMessage = "Az oldal méret 1 és 100 között kell legyen.")]
    public int PageSize { get; set; } = 10;
}