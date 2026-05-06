namespace ASPdotNETticketAPI.Entities;

public class TicketComment //Egy tikethez több komment is tartozhat. Ezért a kommentre külön entitás kell.
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Ticket Ticket { get; set; } = null;
    public AppUser User { get; set; } = null;
}