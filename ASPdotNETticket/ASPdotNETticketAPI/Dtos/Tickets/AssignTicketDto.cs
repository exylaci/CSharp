using System.ComponentModel.DataAnnotations;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class AssignTicketDto //Arra, hogy Agent-hez lehessen rendelni egy Ticketet
{
    [Range(1, int.MaxValue, ErrorMessage = "A hozzárendelt felhasználó azonosítója csak pozitív egész szám lehet.")]
    public int AssignedToUserId { get; set; }
}