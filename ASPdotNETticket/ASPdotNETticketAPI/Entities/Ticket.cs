using ASPdotNETticketAPI.Enums;

namespace ASPdotNETticketAPI.Entities;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketStatus Status { get; set; } = TicketStatus.Open;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
    public int CategoryId { get; set; } //Kibővítjük a programunkat kategóriákkal
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Category Category { get; set; } = null;
}