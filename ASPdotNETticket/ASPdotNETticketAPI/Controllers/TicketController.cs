using ASPdotNETticketAPI.Dtos.Tickets;
using ASPdotNETticketAPI.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ASPdotNETticketAPI.Controllers;

[ApiController]
[Route("api/[controller]")] //Milyen útvonalon érhető el pl localhost/api/Tickets
public class TicketsController : ControllerBase
{
    private static readonly List<TicketDto> Tickets =
    [
        new TicketDto
        {
            Id = 1,
            Title = "Nem tud bejelentkezni",
            Description = "leirás",
            Status = TicketStatus.Open,
            Priority = TicketPriority.High,
            CreatedAt = DateTime.Now
        },
        new TicketDto
        {
            Id = 2,
            Title = "Nem tud bejelentkezni",
            Description = "leirás",
            Status = TicketStatus.Open,
            Priority = TicketPriority.High,
            CreatedAt = DateTime.Now
        }
    ]; //Ideiglenesen, csak hogy legyen benne kezdő adat.

    [HttpGet]
    public ActionResult<IEnumerable<TicketDto>> GetAll()
        // public async Task<ActionResult<IEnumerable<TicketDto>>> GetAll()
    {
        List<TicketDto> tickets = Tickets
            .OrderByDescending(t => t.Id)
            .ToList();
        return Ok(tickets); //OK: 200 státuszkód. Fontos, mert a másik fél a státuszkód alapján folytatja a működését, kezdi el feldolgozni (vagy sem) a kapott adatokat.
    }

    [HttpGet("{id:int}")]
    public ActionResult<TicketDto> GetById(int id) //Nem kell vizsgálni a paramétert, mert csakis és kizárólag int típusú paraméternél hívódik meg ez a függvény
    {
        TicketDto? ticket = Tickets
            .FirstOrDefault(t => t.Id == id);
        if (ticket is null)
        {
            return NotFound(new
            {
                message = $"A {id} azonosítójú tiket nem található."
            }); //NotFound: 404 státuszkód
        }

        return Ok(ticket); //OK: 200 státuszkód
    }

    [HttpPost]
    public ActionResult<TicketDto> Create([FromBody] CreateTicketsDto dto) //A request path-jából szedi ki a változóétédkeit
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            return BadRequest(new { message = "A cím megadása kötelező" });
        }

        int nextId = Tickets.Count == 0 ? 1 : Tickets.Max(t => t.Id) + 1;

        TicketDto ticket = new TicketDto
        {
            Id = nextId,
            Title = dto.Title,
            Description = dto.Description,
            Status = TicketStatus.Open,
            Priority = dto.Priority,
            CreatedAt = DateTime.Now
        };
        Tickets.Add(ticket);

        return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket); //Postnál oké esetén 201-et adunk vissza. Ezért ebbe a CreatedAtAction függvénybe javasolt tenni az visszatérési érték eredményt.
        //A paraméterei megadják melyik végponton kérhető le az újonnan létrehozott elem
        // név, route value id-vel együtt, és maga a ticket

    }
}