using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Tickets;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Enums;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Services.Models;

public class TicketService : ITicketService
{
    private readonly AppDbContext dbContext;

    public TicketService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<TicketDto>> GetAllAsync()
    {
        return dbContext
            .Tickets
            .Include(t => t.Category)
            .OrderByDescending(t => t.Id)
            .Select(MapToTicketDto)
            .ToList();
    }


    public async Task<ServiceResult<TicketDto>> GetByIdAsync(int id)
    {
        Ticket? ticket = await dbContext
            .Tickets
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticket is null)
        {
            return ServiceResult<TicketDto>.NotFound($"A {id} azonosítóju tiket nem található.");
        }

        return ServiceResult<TicketDto>.Success(MapToTicketDto(ticket));
    }

    public async Task<ServiceResult<TicketDto>> CreateAsync(CreateTicketDto dto)
    {
        string normalizedTitle = dto.Title.Trim();
        string normalizedDescription = dto.Description.Trim();

        Category? category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == dto.CategoryId);
        if (category is null)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.CategoryId), "A megadott kategória nem létezik!");
        }

        bool duplicatedTitleExists = await dbContext
            .Tickets
            .AnyAsync(t => t.CategoryId == dto.CategoryId && t.Title.ToLower() == normalizedTitle.ToLower());

        if (duplicatedTitleExists)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Title), "Ebben a ketegóriában már létezik ilyen című hibajegy");
        }

        if (dto.Priority == TicketPriority.Critical && normalizedDescription.Length < 30)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Description), "Kritikus hiba esetén a leírás legalább 30 karakter hosszú kell legyen.");
        }

        Ticket newTicket = new Ticket
        {
            Title = normalizedTitle,
            Description = normalizedDescription,
            Status = TicketStatus.Open,
            Priority = dto.Priority,
            CreatedAt = DateTime.UtcNow,
            CategoryId = category.Id,
            Category = category
        };
        dbContext.Tickets.Add(newTicket);
        await dbContext.SaveChangesAsync();

        return ServiceResult<TicketDto>.Success(MapToTicketDto(newTicket));
    }

    public async Task<ServiceResult<TicketDto>> UpdateAsync(int id, UpdateTicketDto dto)
    {
        Ticket? ticket = await dbContext
            .Tickets
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticket is null)
        {
            return ServiceResult<TicketDto>.NotFound($"A {id} azonosítójú ticket nem található!");
        }

        if (ticket.Status == TicketStatus.Closed)
        {
            return ServiceResult<TicketDto>.Validation(nameof(Ticket.Status), "Lezárt jegy nem módosítható!");
        }

        string normalizedTitle = dto.Title.Trim();
        string normalizedDescription = dto.Description.Trim();

        Category? category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == dto.CategoryId);
        if (category is null)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.CategoryId), "A megadott kategoria nem létezik");
        }

        bool duplicatedTitleExists = await dbContext.Tickets.AnyAsync(t => t.CategoryId == dto.CategoryId && t.Title.ToLower() == normalizedTitle.ToLower());

        if (duplicatedTitleExists)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Title), "Ebben a ketegóriában már létezik ilyen című hibajegy");
        }

        if (dto.Priority == TicketPriority.Critical && normalizedDescription.Length < 30)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Description), "Kritikus hiba esetén a leírás minimum 30 karakter hosszú kell legyen.");
        }

        ticket.Title = normalizedTitle;
        ticket.Description = dto.Description?.Trim() ?? string.Empty;
        ticket.Priority = dto.Priority;
        ticket.CategoryId = category.Id;
        ticket.Category = category;

        await dbContext.SaveChangesAsync();

        return ServiceResult<TicketDto>.Success(MapToTicketDto(ticket));
    }

    public async Task<ServiceResult<TicketDto>> UpdateStatusAsync(int id, UpdateTicketStatusDto dto)
    {
        Ticket? ticket = await dbContext
            .Tickets
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticket is null)
        {
            return ServiceResult<TicketDto>.NotFound($"A {id} azonosítójú ticket nem található!");
        }

        if (ticket.Status == dto.Status)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Status), "A tiketnek már eleve ez a státusza.");
        }

        if (ticket.Status == TicketStatus.Open && dto.Status == TicketStatus.Closed)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Status), "Open állapotút nem lehet egyből lezárni");
        }

        if (ticket.Status == TicketStatus.Closed && dto.Status != TicketStatus.Closed)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Status), "Lezárt ticketet nem lehet újra nyitni");
        }

        if (ticket.Status == TicketStatus.Resolved && dto.Status == TicketStatus.Open)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Status), "Megoldott ticketet nem lehet újra nyitni");
        }

        ticket.Status = dto.Status;
        await dbContext.SaveChangesAsync();
        return ServiceResult<TicketDto>.Success(MapToTicketDto(ticket));
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        Ticket? ticket = await dbContext.Tickets
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticket is null)
        {
            return ServiceResult.NotFound($"A {id} azonosítóju tiket nem található.");
        }

        if (ticket.Status == TicketStatus.Closed)
        {
            return ServiceResult.Validation(nameof(ticket.Status), "Lezárt ticket nem törölhető");
        }

        dbContext.Tickets.Remove(ticket);
        await dbContext.SaveChangesAsync();
        return ServiceResult.Success(); //OK: 200 státuszkód
    }

    private static TicketDto MapToTicketDto(Ticket ticket)
    {
        return new TicketDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Status = ticket.Status,
            Priority = ticket.Priority,
            CategoryId = ticket.CategoryId,
            CategoryName = ticket.Category.Name,
            CreatedAt = ticket.CreatedAt
        };
    }
}