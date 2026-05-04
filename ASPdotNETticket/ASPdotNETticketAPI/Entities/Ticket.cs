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
    public int? CreatedByUserId { get; set; } //Ki hozta létre (nullable: Mert a korábban létrehozott ticketeknél nincs ilyen adat. Ha egyből az elején felvettünk volna ilyen paramétert is, akkor nem kellene nullable-nek lennie.)
    public int? AssignedToUserId { get; set; } //Kihez van rendelve
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Category Category { get; set; } = null;
    public AppUser? CreatedByUser { get; set; }
    public AppUser? AssignedToUser { get; set; }
}