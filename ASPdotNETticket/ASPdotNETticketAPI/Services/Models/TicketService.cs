using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Common;
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

    public async Task<PagedResultDto<TicketDto>> GetAllAsync(GetTicketsQueryDto query)
    {
        IQueryable<Ticket> ticketsQuery = dbContext
            .Tickets
            .AsNoTracking() //Csak olvasunk, nem akarjuk a betöltött adatokat módosítani
            .Include(t => t.Category);

        //1.Keresés
        string normalizedSearchTerm = query.SearchTerm?.Trim();
        if (!string.IsNullOrWhiteSpace(normalizedSearchTerm))
        {
            string? loweredSearchTerm = normalizedSearchTerm.ToLower();

            ticketsQuery = ticketsQuery.Where(t => t.Title.ToLower().Contains(loweredSearchTerm) || //Címben 
                                                   t.Description.ToLower().Contains(loweredSearchTerm)); //és leírásban is keresünk
        }

        //2.SZURES

        if (query.Status.HasValue)
        {
            ticketsQuery = ticketsQuery.Where(t => t.Status == query.Status.Value);
        }

        if (query.Priority.HasValue)
        {
            ticketsQuery = ticketsQuery.Where(t => t.Priority == query.Priority.Value);
        }

        if (query.CategoryId.HasValue)
        {
            ticketsQuery = ticketsQuery.Where(t => t.CategoryId == query.CategoryId.Value);
        }

        //3. LAPOZAS
        string normalizedSortBy = query.SortBy?.Trim().ToLowerInvariant() ?? "createdat"; //culture info alapján tudja az ékezetes karaktereket is kisbetűsre cserélni
        string normalizedSortDirection = query.SortDirection?.Trim().ToLowerInvariant() ?? "desc";
        bool isAscending = normalizedSortDirection == "asc";

        ticketsQuery = (normalizedSortBy, isAscending) switch
        {
            ("title", true) => ticketsQuery.OrderBy(t => t.Title),
            ("title", false) => ticketsQuery.OrderByDescending(t => t.Title),
            ("priority", true) => ticketsQuery.OrderBy(t => t.Priority),
            ("priority", false) => ticketsQuery.OrderByDescending(t => t.Priority),
            ("status", true) => ticketsQuery.OrderBy(t => t.Status),
            ("status", false) => ticketsQuery.OrderByDescending(t => t.Status),
            ("category", true) => ticketsQuery.OrderBy(t => t.Category),
            ("category", false) => ticketsQuery.OrderByDescending(t => t.Category),
            ("createdat", true) => ticketsQuery.OrderBy(t => t.CreatedAt),
            ("createdat", false) => ticketsQuery.OrderByDescending(t => t.CreatedAt),
            _ => ticketsQuery.OrderByDescending(t => t.CreatedAt)
        };

        //4.találatszám
        int totalCount = await ticketsQuery.CountAsync();


        //5. Lapozas
        //--page1 -> skip 0
        //--page2 -> skip pagesize
        //--page3 -> skip pagesize*2

        int skip = (query.PageNumber - 1) * query.PageSize;

        List<TicketDto> items = await ticketsQuery
            .Skip(skip)
            .Take(query.PageSize)
            .Select(t => new TicketDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Priority = t.Priority,
                CategoryId = t.CategoryId,
                CategoryName = t.Category.Name,
                CreatedAt = t.CreatedAt
            })
            .ToListAsync();

        //6. METAADATOK
        int totalPages = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)query.PageSize);

        return new PagedResultDto<TicketDto>
        {
            Items = items,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            TotalCount = totalCount,
            TotalPages = totalPages
            // HasPreviousPage = query.PageNumber > 1,
            // HasNextPage = query.PageNumber < totalPages
        };
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