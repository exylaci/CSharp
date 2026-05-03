using System.ComponentModel.DataAnnotations;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class AssignTicketDto
{
    [Range(1, int.MaxValue, ErrorMessage = "A hozzárendelt felhasználó azonosítója csak pozitív egész szám lehet.")]
    public int AssignedToUserId { get; set; }
}