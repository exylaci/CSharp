using ASPdotNETticketAPI.Dtos.Users;

namespace ASPdotNETticketAPI.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public ICollection<Ticket> CreatedTickets { get; set; } = new List<Ticket>();   //Milyen Ticket-eket hozott ő létre
    public ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();  //Milyen Ticketek vannak hozzárendelve
}