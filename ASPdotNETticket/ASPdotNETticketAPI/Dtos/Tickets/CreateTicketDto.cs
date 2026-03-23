using ASPdotNETticketAPI.Enums;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class CreateTicketsDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
}