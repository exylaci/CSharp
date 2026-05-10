using System.Security.Claims;
using ASPdotNETticketAPI.Constants;
using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Common;
using ASPdotNETticketAPI.Dtos.Tickets;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Enums;
using ASPdotNETticketAPI.Services.Interfaces;
using ASPdotNETticketAPI.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Controllers;

[ApiController]
[Route("api/[controller]")] //Milyen útvonalon érhető el pl localhost/api/Tickets
public class TicketsController : ControllerBase
{
    private readonly ITicketService ticketService;

    public TicketsController(ITicketService ticketService)
    {
        this.ticketService = ticketService; //dependency Injection: a kontruktorban az adatbázis "elérése"
    }

    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Agent)]
    [HttpGet] //lekérdezésnél
    public async Task<ActionResult<PagedResultDto<TicketDto>>> GetAll([FromQuery] GetTicketsQueryDto query)
    {
        PagedResultDto<TicketDto> result = await ticketService.GetAllAsync(query);

        return Ok(result); //OK: 200 státuszkód
    }


    [Authorize]
    [HttpGet("my-created")]
    public async Task<ActionResult<PagedResultDto<TicketDto>>> GetMyCreated([FromQuery] GetTicketsQueryDto query)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        PagedResultDto<TicketDto> result = await ticketService.GetMyCreatedAsync(currentUserId, query);
        return Ok(result);
    }

    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Agent)]
    [HttpGet("my-assigned")]
    public async Task<ActionResult<PagedResultDto<TicketDto>>> GetMyAssigned([FromQuery] GetTicketsQueryDto query)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }


        PagedResultDto<TicketDto> result = await ticketService.GetMyAssignedAsync(currentUserId, query);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketDetailDto>> GetById(int id) //Nem kell vizsgálni a paramétert, mert csakis és kizárólag int típusú paraméter esetén hívódik meg ez a függvény
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A token nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<TicketDetailDto> result = await ticketService.GetByIdAsync(id, currentUserId, currentUserRole);

        if (result.IsNotFound)
        {
            return Unauthorized(new { message = result.Message });
        }

        return Ok(result.Data); //OK: 200 státuszkód. Ráérünk csak akkor konvertálni, ha van ilyen. Felesleges ezzel terhelni a processzort még a viszgálat előtt.
    }

    [Authorize] //Ha nincs érvényes token, akkor az endpoint nem jut el a kontroller kódjára. (Védett a Create.)
    [HttpPost] //létrehozásnál
    public async Task<ActionResult<TicketDto>> Create([FromBody] CreateTicketDto dto) //[FromBody]: A request path-jából kiszedi és a dto változóba beteszi a értékeket
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        ServiceResult<TicketDto> result = await ticketService.CreateAsync(dto, currentUserId);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result.Data); //Ha eljutott eddig, akkor biztos h nem null a result.Data
    }

    [Authorize]
    [HttpPut("{id:int}")] //teljes adat lecserélésénél
    public async Task<ActionResult<TicketDto>> Update(int id, [FromBody] UpdateTicketDto dto) //Csak módosításra használjuk
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A token nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<TicketDto>? result = await ticketService.UpdateAsync(id, dto, currentUserId, currentUserRole);

        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Agent)]
    [HttpPatch("{id:int}/status")] //adatrészlet módosításánál
    public async Task<ActionResult<TicketDto>> UpdateStatus(int id, [FromBody] UpdateTicketStatusDto dto)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A token nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<TicketDto>? result = await ticketService.UpdateStatusAsync(id, dto, currentUserId, currentUserRole);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Agent)]
    [HttpPost("{id:int}/assign")]
    public async Task<ActionResult<TicketDto>> Assign(int id, [FromBody] AssignTicketDto dto)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A token nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<TicketDto>? result = await ticketService.AssignAsync(id, dto, currentUserId, currentUserRole);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Agent)]
    [HttpPatch("{id:int}/take")]
    public async Task<ActionResult<TicketDto>> Take(int id, [FromBody] TakeTicketDto dto) //Attól hogy a DTO még üres, a végpont elkészíthető. Nyílván ilyenkor mivel nincs benne aat, nem lesz érdemi eredménye a függvényünknek. Az (üres)adatok ellenőrzésén fennakad.
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A token nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<TicketDto> result = await ticketService.TakeAsync(id, currentUserId, currentUserRole);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data); //Nincs data contarct (DTO üres), hiányos a jegy, nem lesz az eredményben sem semmi sem, el sem jut eddig. 
    }

    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Agent)]
    [HttpPatch("{id:int}/resolve")]
    public async Task<ActionResult<TicketDto>> Resolve(int id, [FromBody] WorkflowActionDto dto)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A token nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<TicketDto>? result = await ticketService.ResolveAsync(id, currentUserId, currentUserRole, dto);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [Authorize]
    [HttpPatch("{id:int}/close")]
    public async Task<ActionResult<TicketDto>> Close(int id, [FromBody] WorkflowActionDto dto)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole)) //Muszáj ellenőrizni a szerepkört, mert bár minden jogosultsággal megengedett a jegy lezárása, de mivan, ha nincs a dto-ban a szerepkör adat.
        {
            return Unauthorized(new { message = $"A token nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<TicketDto>? result = await ticketService.CloseAsync(id, currentUserId, currentUserRole, dto);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [Authorize]
    [HttpPatch("{id:int}/reopen")]
    public async Task<ActionResult<TicketDto>> Reopen(int id, [FromBody] WorkflowActionDto dto)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return Unauthorized(new
            {
                message = "A token nem tartalmaz érvényes felhasználót!"
            });
        }

        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A token nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<TicketDto>? result = await ticketService.ReopenAsync(id, currentUserId, currentUserRole, dto);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [Authorize(Roles = RoleNames.Admin)]
    [HttpDelete("{id:int}")] //törlésnél
    public async Task<ActionResult<TicketDto>> Delete(int id)
    {
        ServiceResult? result = await ticketService.DeleteAsync(id);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return NoContent();
    }

    private ActionResult CreateActionResultFromServiceResult(ServiceResult result)
    {
        if (result.IsNotFound)
        {
            return NotFound(new { message = result.Message });
        }

        return ValidationProblem(new ValidationProblemDetails(result.Errors));
    }

    private ActionResult CreateActionResultFromServiceResult<T>(ServiceResult<T> result)
    {
        if (result.IsNotFound)
        {
            return NotFound(new { message = result.Message });
        }

        return ValidationProblem(new ValidationProblemDetails(result.Errors));
    }

    private bool TryGetCurrentUserId(out int userId)
    {
        string userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier); //A json web tokenből a name identifier clame-et olvassuk ki és ezzel a name identifier json webtokennel olvassuk ki az adatbázisból a usert
        return int.TryParse(userIdClaim, out userId);
    }

    private string? GetCurrentUserRole()
    {
        return User.FindFirstValue(ClaimTypes.Role);
    }
}