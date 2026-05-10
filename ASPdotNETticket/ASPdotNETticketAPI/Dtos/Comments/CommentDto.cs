namespace ASPdotNETticketAPI.Dtos.Comments;

public class CommentDto //A kommentek lekérésérhez tartozó DTO
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public int UserId { get; set; }
    public string UserFullName { get; set; } = string.Empty; //ID alapján lekérdezhetné a frontend, de ez neki plusz logika lenne, és az a cél, hogy a kliens minél egyszerűbb felépítésű legyen ezért inkább ide eleve betesszük a user nevét is, még ha ez néha felesleges adat és redundáns információ is, 
    public string UserRole { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}