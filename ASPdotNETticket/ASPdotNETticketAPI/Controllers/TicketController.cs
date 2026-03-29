using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Tickets;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Controllers;

[ApiController]
[Route("api/[controller]")] //Milyen útvonalon érhető el pl localhost/api/Tickets
public class TicketsController : ControllerBase
{
    public readonly AppDbContext dbContext;

    public TicketsController(AppDbContext dbContext)
    {
        this.dbContext = dbContext; //dependency Injection: a kontruktorban az adatbázis "elérése"
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketDto>>> GetAll()
    {
        List<TicketDto> tickets = await dbContext.Tickets
            .Include(t => t.Category) //A Priority tábla JOIN-ja objektum szinten történik, nem natívan
            .OrderByDescending(t => t.Id) //Csökkenző sorrendbe rendezés
            .Select(t => new TicketDto //Bepakolja DTO-ba a megkapot adatot 
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority,
                CategoryId = t.CategoryId,
                CategoryName = t.Category.Name,
                CreatedAt = t.CreatedAt
            }).ToListAsync(); //List-et csinál az eredmény kupacból

        return Ok(tickets); //OK: 200 státuszkód. Fontos, mert a másik fél a státuszkód alapján folytatja a működését, kezdi el feldolgozni (vagy sem) a kapott adatokat.
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketDto>> GetById(int id) //Nem kell vizsgálni a paramétert, mert csakis és kizárólag int típusú paraméternél hívódik meg ez a függvény
    {
        TicketDto? ticket = await dbContext.Tickets
            .Include(t => t.Category)
            .Where(t => t.Id == id)
            .Select(t => new TicketDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    Priority = t.Priority,
                    CategoryId = t.CategoryId,
                    CategoryName = t.Category.Name,
                    CreatedAt = t.CreatedAt
                }
            ).FirstOrDefaultAsync();
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
    public async Task<ActionResult<TicketDto>> Create([FromBody] CreateTicketsDto dto) //A request path-jából szedi ki a változóétédkeit
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            return BadRequest(new { message = "A cím megadása kötelező" });
        }

        bool categoryExists = await dbContext.Categories.AnyAsync(c => c.Id == dto.CategoryId);
        if (!categoryExists)    //Ellenőrizni kell, hogy a kapott kategória ID létezik-e
        {
            return BadRequest(
                new { message = "A megadott kategoria nem létezik" });
        }

        Ticket newTicket = new Ticket   //A http requestben kapott DTO adatok alapján létrehozunk egy ticketet.
        {
            //Az ID-t majd az adatbázis intézi
            Title = dto.Title,
            Description = dto.Description,
            Status = TicketStatus.Open,
            Priority = dto.Priority,
            CreatedAt = DateTime.UtcNow,
            CategoryId = dto.CategoryId
        };
        dbContext.Tickets.Add(newTicket);   //Betesszük az adatbázisunkba
        await dbContext.SaveChangesAsync(); //és el is mentjük  

        TicketDto createdTicket = await dbContext.Tickets //A http request-re visszaadandó DTO-t pedig "az eltárolás sikeressége ellenőrzése képpen" egyből le is kérdezzük az adatbázisból a betárolt új elemet, és azt adjuk vissza a DTO-ban. 
            .Include(t => t.Category)
            .Where(t => t.Id == newTicket.Id)
            .Select(t => new TicketDto  //A megtalált elem adatait alapján létrehozunk egy új DTO-t
            {
                Id = t.Id,  //És itt kapjuk meg az új elem ID-ját is
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority,
                CategoryId = t.CategoryId,
                CategoryName = t.Category.Name,
                CreatedAt = t.CreatedAt
            }).FirstAsync();

        return CreatedAtAction(nameof(GetById), new { id = createdTicket.Id }, createdTicket); //Postnál, oké esetén 201-et adunk vissza. Ezért ebbe a CreatedAtAction függvénybe javasolt tenni az visszatérési érték eredményt.
        //A paraméterei megadják melyik végponton kérhető le az újonnan létrehozott elem
        // név, route value id-vel együtt, és maga a ticket
    }
}