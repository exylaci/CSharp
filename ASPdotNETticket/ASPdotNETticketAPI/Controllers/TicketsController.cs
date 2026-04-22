using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Tickets;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Enums;
using ASPdotNETticketAPI.Services.Interfaces;
using ASPdotNETticketAPI.Services.Models;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketDto>>> GetAll()
    {
        List<TicketDto> result = await ticketService.GetAllAsync();

        return Ok(result); //OK: 200 státuszkód. Fontos, mert a másik fél a státuszkód alapján folytatja a működését, kezdi el feldolgozni (vagy sem) a kapott adatokat.
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketDto>> GetById(int id) //Nem kell vizsgálni a paramétert, mert csakis és kizárólag int típusú paraméter esetén hívódik meg ez a függvény
    {
        ServiceResult<TicketDto>? result = await ticketService.GetByIdAsync(id);
        if (result.IsNotFound)
        {
            return NotFound(new { message = $"A {id} azonosítóju tiket nem található." });
        }

        return Ok(result.Data); //OK: 200 státuszkód. Ráérünk csak akkor konvertálni, ha van ilyen. Felesleges ezzel terhelni a processzort még a viszgálat előtt.
    }

    [HttpPost]
    public async Task<ActionResult<TicketDto>> Create([FromBody] CreateTicketDto dto) //[FromBody]: A request path-jából kiszedi és a dto változóba beteszi a értékeket
    {
        ServiceResult<TicketDto>? result = await ticketService.CreateAsync(dto);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result.Data); //Ha eljutott eddig, akoor biztos h nem null a result.Data
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TicketDto>> Update(int id, [FromBody] UpdateTicketDto dto) //Csak módosításra használjuk
    {
        ServiceResult<TicketDto>? result = await ticketService.UpdateAsync(id, dto);

        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [HttpPatch("{id:int}/status")]
    public async Task<ActionResult<TicketDto>> UpdateStatus(int id, [FromBody] UpdateTicketStatusDto dto)
    {
        ServiceResult<TicketDto>? result = await ticketService.UpdateStatusAsync(id, dto);
        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return Ok(result.Data);
    }

    [HttpDelete("{id:int}")]
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
}