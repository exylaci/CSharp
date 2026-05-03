using System.ComponentModel.DataAnnotations;
using ASPdotNETticketAPI.Enums;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class CreateTicketDto //Bejövő modell
{
    [Required(ErrorMessage = "A cím megadása kötelező")] //Kötelezőn megadandó adatra
    [StringLength(200, MinimumLength = 5, ErrorMessage = "A cím legalább 5 karakter hosszú kell legyen, de nem lehet több 200-nál.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "A leírás megadása kötelező")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "A leírás legalább 5 karakter hosszú kell legyen, de nem lehet több 2000-nál.")]
    public string Description { get; set; } = string.Empty;

    [EnumDataType(typeof(TicketPriority), ErrorMessage = "Érvénytelen prioritási érték")]
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;

    [Range(1, int.MaxValue, ErrorMessage = "A kategória azonosítója csak pozitív egész szám lehet!")]
    public int CategoryId { get; set; }
}