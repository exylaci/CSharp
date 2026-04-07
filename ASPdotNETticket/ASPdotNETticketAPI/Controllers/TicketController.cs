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
    private readonly AppDbContext dbContext;

    public TicketsController(AppDbContext dbContext)
    {
        this.dbContext = dbContext; //dependency Injection: a kontruktorban az adatbázis "elérése"
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketDto>>> GetAll()
    {
        List<TicketDto> tickets = dbContext
            .Tickets
            .Include(t => t.Category) //A Priority tábla JOIN-ja objektum szinten történik, nem natívan
            .OrderByDescending(t => t.Id) //Csökkenző sorrendbe rendezés
            .Select(MapToTicketDto) //Átláthatóbb lett a lekérdezés külső, saját map függvénnyel
            .ToList(); //List-et csinál az eredmény kupacból

        return Ok(tickets); //OK: 200 státuszkód. Fontos, mert a másik fél a státuszkód alapján folytatja a működését, kezdi el feldolgozni (vagy sem) a kapott adatokat.
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketDto>> GetById(int id) //Nem kell vizsgálni a paramétert, mert csakis és kizárólag int típusú paraméter esetén hívódik meg ez a függvény
    {
        Ticket? ticket = await dbContext
            .Tickets
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (ticket is null)
        {
            return NotFound(new { message = $"A {id} azonosítójú tiket nem található." }); //NotFound: 404 státuszkód
        }

        return Ok(MapToTicketDto(ticket)); //OK: 200 státuszkód. Ráérünk csak akkor konvertálni, ha van ilyen. Felesleges ezzel terhelni a processzort még a viszgálat előtt.
    }

    [HttpPost]
    public async Task<ActionResult<TicketDto>> Create([FromBody] CreateTicketsDto dto) //[FromBody]: A request path-jából kiszedi és a dto változóba beteszi a értékeket
    {
        //Nem kell ellenőrizni a Title tartalmát, mert a DTO-ban a validációs szabályoknál ez már megtörténik, ide nem tud szabályt sértő érték eljutni.

        Category? category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == dto.CategoryId);
        if (category is null) //Az továbbra is ellenőrizni kell, hogy a dto-ban kapott kategória ID létezik-e adatbázis szinten
        {
            AddBusinessRuleError(nameof(dto.CategoryId), "A megadott kategoria nem létezik."); //Üzleti döntés, hogy a kategóriát meg kell adni, ezért BusinesRuleError-t dobunk BadRFequest helyett
            return ValidationProblem(ModelState);
        }

        string normalizedTitle = dto.Title.Trim();
        bool duplicatedTitle = await dbContext.Tickets.AnyAsync(t =>
            t.CategoryId == dto.CategoryId && t.Title.ToLower() == normalizedTitle.ToLower());  //pl lehet olyan szabály, hogy a címek egyedik kell legyenek 
        if (duplicatedTitle)
        {
            AddBusinessRuleError(nameof(dto.Title), "Ebben a kategóriában már létezik ilyen című ticket.");
            return ValidationProblem(ModelState);
        }

        string normalizedDescription = dto.Description?.Trim() ?? string.Empty;
        if (dto.Priority == TicketPriority.Critical && normalizedDescription.Length < 30)   //pl lehet olyan szabály, hogy a leírás legalább milyen hosszú kell legyen 
        {
            AddBusinessRuleError(nameof(dto.Description), "Kritikus hiba esetén, a leírás legalább 30 karakter hosszú kell legyen.");
            return ValidationProblem(ModelState);
        }

        Ticket newTicket = new Ticket //A http requestben kapott DTO adatok alapján létrehozunk egy ticketet.
        {
            //Az ID-t majd az adatbázis intézi
            Title = normalizedTitle,
            Description = normalizedDescription,
            Status = TicketStatus.Open,
            Priority = dto.Priority,
            CreatedAt = DateTime.UtcNow,
            CategoryId = category.Id,
            Category = category
        };
        dbContext.Tickets.Add(newTicket); //Betesszük az adatbázisunkba
        await dbContext.SaveChangesAsync(); //és el is mentjük  
        TicketDto createdTicket = MapToTicketDto(newTicket); //Ha eddig a pontig eljutott a program, akkor biztos helyes adat van a newTicket-ben. Felesleges újból külön lekérdezni az adatbázisból az értékeit. 
        return CreatedAtAction(nameof(GetById), new { id = createdTicket.Id }, createdTicket); //Postnál, oké esetén 201-et adunk vissza. Ezért ebbe a CreatedAtAction függvénybe javasolt tenni a visszatérési érték eredményt.
        //A paraméterei megadják melyik végponton kérhető le az újonnan létrehozott elem
        // név, route value id-vel együtt, és maga a ticket
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TicketDto>> Update(int id, [FromBody] UpdateTicketDto dto) //Csak módosításra használjuk
    {
        Ticket? ticket = await dbContext //Megkeressük, hogy létezik-e ez a jegy ID
            .Tickets
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticket is null) //Nem található
        {
            return NotFound(new { message = $"A {id} azonosítójú ticket nem található!" });
        }

        if (ticket.Status == TicketStatus.Closed)
        {
            AddBusinessRuleError(nameof(Ticket.Status), "Lezárt jegy nem módosítható!");
            return ValidationProblem(ModelState);
        }

        string normalizedTitle = dto.Title.Trim();
        string normalizedDescription = dto.Description.Trim();

        Category? category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == dto.CategoryId);
        if (category is null)
        {
            AddBusinessRuleError(nameof(dto.CategoryId), "A megadott kategoria nem létezik");
            return ValidationProblem(ModelState);
        }

        bool duplicatedTitleExists = await dbContext.Tickets.AnyAsync(t => t.CategoryId == dto.CategoryId && t.Title.ToLower() == normalizedTitle.ToLower());

        if (duplicatedTitleExists)
        {
            AddBusinessRuleError(nameof(dto.Title), "Ebben a ketegóriában már létezik ilyen című hibajegy");
            return ValidationProblem(ModelState);
        }

        if (dto.Priority == TicketPriority.Critical && normalizedDescription.Length < 30)
        {
            AddBusinessRuleError(nameof(dto.Description), "Kritikus hiba esetén, a leírás legalább 30 karakter hosszú kell legyen.");
            return ValidationProblem(ModelState);
        }

        ticket.Title = normalizedTitle;
        ticket.Description = normalizedDescription;
        ticket.Priority = dto.Priority;
        ticket.CategoryId = category.Id;
        ticket.Category = category;

        await dbContext.SaveChangesAsync(); //változtatás mentése

        return Ok(MapToTicketDto(ticket));
    }

    [HttpPatch("{id:int}/status")]
    public async Task<ActionResult<TicketDto>> UpdateStatus(int id, [FromBody] UpdateTicketStatusDto dto)
    {
        Ticket? ticket = await dbContext
            .Tickets
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticket is null)
        {
            return NotFound(new { message = $"A {id} azonosítójú ticket nem található!" });
        }

        if (ticket.Status == dto.Status)    //Feledsleges ugyanazt az adator újra beleárolni
        {
            AddBusinessRuleError(nameof(dto.Status), "A tiketnek már eleve ez a státusza.");
            return ValidationProblem(ModelState);
        }

        if (ticket.Status == TicketStatus.Open && dto.Status == TicketStatus.Closed)
        {
            AddBusinessRuleError(nameof(dto.Status), "Open állapotú ticketet nem lehet egyből lezárni");
            return ValidationProblem(ModelState);
        }

        if (ticket.Status == TicketStatus.Closed && dto.Status != TicketStatus.Closed)  //Bár a DTO-t nem kellene vizsgálni, de a könnyebb érthetőség kedvéért odatesszük ezt a feltételrészt is
        {
            AddBusinessRuleError(nameof(dto.Status), "Lezárt ticketet nem lehet visszanyitni");
            return ValidationProblem(ModelState);
        }

        if (ticket.Status == TicketStatus.Resolved && dto.Status == TicketStatus.Open)
        {
            AddBusinessRuleError(nameof(dto.Status), "Megoldott ticketet nem lehet előlről kezdeni");
            return ValidationProblem(ModelState);
        }

        ticket.Status = dto.Status;
        await dbContext.SaveChangesAsync();
        return Ok(MapToTicketDto(ticket));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<TicketDto>> Delete(int id)
    {
        Ticket? ticket = await dbContext.Tickets
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticket is null)
        {
            return NotFound(new
            {
                message = $"A {id} azonosítóju tiket nem található."
            });
        }

        if (ticket.Status == TicketStatus.Closed)
        {
            AddBusinessRuleError(nameof(ticket.Status), "Lezárt ticket nem törölhető");
            return ValidationProblem(ModelState);
        }

        dbContext.Tickets.Remove(ticket); //Jegy törlése a belső listánkból
        await dbContext.SaveChangesAsync(); //a belső lista mentése az adatbázisba is
        return NoContent(); //OK delete: 200 státuszkód
    }

    private void AddBusinessRuleError(string key, string message) //Saját üzleti logika "hiba"üzenet.
    {
        ModelState.AddModelError(key, message); //ASP .NET Core automatikusan betölti a ModelState-et és validációs hibaként fogja kezelni
    }

    private TicketDto MapToTicketDto(Ticket ticket) //Kiszervezzük függvénybe a konverterünket, ami kézi mapper-rel bepakoljuk a megkapot adatot DTO-ba 
    {
        return new TicketDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Status = ticket.Status,
            Priority = ticket.Priority,
            CategoryId = ticket.CategoryId,
            CategoryName = ticket.Category.Name, //Itt azt feltételezzük, hogy a Category már be van töltve. Ezt az .Include()-dal biztosítjuk.
            CreatedAt = ticket.CreatedAt
        };
    }
}