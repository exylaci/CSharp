using ASPdotNETticketAPI.Enums;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class TicketDto //Ezt adjuk vissza egy GET request kérésre (Kimenő modell)
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketStatus Status { get; set; } = TicketStatus.Open;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
    public DateTime CreatedAt { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public int? CreatedByUserId { get; set; }
    public string CreatedByUserName { get; set; } = string.Empty;
    public int? AssignedToUserId { get; set; }
    public string AssignedToUserName { get; set; } = string.Empty;
}