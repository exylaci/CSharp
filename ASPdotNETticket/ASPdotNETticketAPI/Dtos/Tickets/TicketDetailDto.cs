using ASPdotNETticketAPI.Dtos.Comments;
using ASPdotNETticketAPI.Enums;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class TicketDetailDto //Ezt adjuk vissza a jegyről egy részletes GET request lekérdezésnél. Abszolút minden adat benne van.egy  (Kimenő modell)
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketStatus Status { get; set; } = TicketStatus.Open;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public int? CreatedByUserId { get; set; }
    public string CreatedByUserName { get; set; } = string.Empty;
    public int? AssignedToUserId { get; set; }
    public string AssignedToUserName { get; set; } = string.Empty;
    public List<CommentDto> Comments { get; set; } = []; //Mivel több komment is tartozhat hozzá, ezért a komment(ek) mindnig egy collectióban van(nak).
}