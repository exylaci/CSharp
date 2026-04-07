using System.ComponentModel.DataAnnotations;
using ASPdotNETticketAPI.Enums;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class UpdateTicketStatusDto
{
    [EnumDataType(typeof(TicketStatus), ErrorMessage = "Érvénytelen státusz érték")]
    public TicketStatus Status { get; set; }
}