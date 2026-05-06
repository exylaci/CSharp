using ASPdotNETticketAPI.Constants;
using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Comments;
using ASPdotNETticketAPI.Dtos.Common;
using ASPdotNETticketAPI.Dtos.Tickets;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Enums;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
        IQueryable<Ticket> ticketsQuery = BuildBaseTicketQuery();
        return await CreatePagedResultAsync(ticketsQuery, query);
    }

    public async Task<PagedResultDto<TicketDto>> GetMyCreatedAsync(int currentUserId, GetTicketsQueryDto query)
    {
        IQueryable<Ticket> ticketsQuery = BuildBaseTicketQuery()
            .Where(t => t.CreatedByUserId == currentUserId);
        return await CreatePagedResultAsync(ticketsQuery, query);
    }

    public async Task<PagedResultDto<TicketDto>> GetMyAssignedAsync(int currentUserId, GetTicketsQueryDto query)
    {
        IQueryable<Ticket> ticketsQuery = BuildBaseTicketQuery()
            .Where(t => t.AssignedToUserId == currentUserId);
        return await CreatePagedResultAsync(ticketsQuery, query);
    }

    public async Task<ServiceResult<TicketDetailDto>> GetByIdAsync(int id, int currentUserId, string currentUserRole)
    {
        Ticket? ticket = await LoadTrackedTicketWithRelationsAsync(id);
        if (ticket is null)
        {
            return ServiceResult<TicketDetailDto>.NotFound($"A {id} azonosítójú tiket nem található.");
        }

        if (!CanAccessTicket(ticket, currentUserId, currentUserRole))
        {
            return ServiceResult<TicketDetailDto>.NotFound($"A {id} azonosítójú tiket nem található.");
        }

        return ServiceResult<TicketDetailDto>.Success(MapToTicketDetailDto(ticket));
    }

    public async Task<ServiceResult<TicketDto>> CreateAsync(CreateTicketDto dto, int currentUserId)
    {
        string normalizedTitle = dto.Title.Trim();
        string normalizedDescription = dto.Description.Trim();

        AppUser? creator = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == currentUserId && u.IsActive);
        if (creator is null)
        {
            return ServiceResult<TicketDto>.Validation("user", "A bejelentkezett felhasználó nem található, vagy inaktív!");
        }


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
            Category = category,
            CreatedByUserId = currentUserId,
            AssignedToUser = null
        };
        dbContext.Tickets.Add(newTicket);
        await dbContext.SaveChangesAsync();

        Ticket? createdTicket = await LoadTrackedTicketWithRelationsAsync(newTicket.Id);
        return ServiceResult<TicketDto>.Success(MapToTicketDto(createdTicket));
    }

    public async Task<ServiceResult<TicketDto>> UpdateAsync(int id, UpdateTicketDto dto, int currentUserId, string currentUserRole)
    {
        Ticket? ticket = await LoadTrackedTicketWithRelationsAsync(id);
        if (ticket is null)
        {
            return ServiceResult<TicketDto>.NotFound($"A {id} azonosítójú ticket nem található!");
        }

        if (currentUserRole == RoleNames.User && ticket.CreatedByUserId != currentUserId)
        {
            return ServiceResult<TicketDto>.NotFound($"A {id} azonosítójú ticket nem található!");
        }

        if (currentUserRole == RoleNames.User && ticket.Status != TicketStatus.Open)
        {
            return ServiceResult<TicketDto>.Validation(nameof(ticket.Status), "Felhasználó csak open állapotú saját ticketet múdosíthat.");
        }

        if (currentUserRole == RoleNames.User && ticket.Status == TicketStatus.Closed)
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

        Ticket? updatedTicket = await LoadTrackedTicketWithRelationsAsync(ticket.Id);
        return ServiceResult<TicketDto>.Success(MapToTicketDto(updatedTicket));
    }

    public async Task<ServiceResult<TicketDto>> UpdateStatusAsync(int id, UpdateTicketStatusDto dto, int currentUserId, string currentUserRole)
    {
        Ticket? ticket = await LoadTrackedTicketWithRelationsAsync(id);
        if (ticket is null)
        {
            return ServiceResult<TicketDto>.NotFound($"A {id} azonosítójú ticket nem található!");
        }

        if (ticket.Status == dto.Status)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Status), "A tiketnek már eleve ez a státusza.");
        }


        if (currentUserRole == RoleNames.Agent && ticket.AssignedToUserId != currentUserId)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.Status), "Agentként csak a hozzád rendelt ticket státuszát módosíthatod.");
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

        Ticket? updatedTicket = await LoadTrackedTicketWithRelationsAsync(ticket.Id);
        return ServiceResult<TicketDto>.Success(MapToTicketDto(updatedTicket));
    }


    public async Task<ServiceResult<TicketDto>> AssignAsync(int id, AssignTicketDto dto, int currentUserId, string currentUserRole)
    {
        Ticket? ticket = await LoadTrackedTicketWithRelationsAsync(id);
        if (ticket is null)
        {
            return ServiceResult<TicketDto>.NotFound($"A {id} azonosítójú ticket nem található");
        }

        if (ticket.Status == TicketStatus.Closed)
        {
            return ServiceResult<TicketDto>.Validation(nameof(ticket.Status), "Lezárt ticket nem rendelhető hozzá agenthez.");
        }

        AppUser? targetUser = await dbContext.Users
            .FirstOrDefaultAsync(u =>
                u.Id == dto.AssignedToUserId
                && u.IsActive
                && u.Role == RoleNames.Agent);

        if (targetUser is null)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.AssignedToUserId), "A megadott user nem létezik, vagy inaktív agent.");
        }

        if (currentUserRole == RoleNames.Agent && dto.AssignedToUserId != currentUserId)
        {
            return ServiceResult<TicketDto>.Validation(nameof(dto.AssignedToUserId), "Agentként csak saját magadhoz rendelhetsz ticketet.");
        }

        ticket.AssignedToUserId = targetUser.Id;
        await dbContext.SaveChangesAsync();
        Ticket? updatedTicket = await LoadTrackedTicketWithRelationsAsync(ticket.Id);
        return ServiceResult<TicketDto>.Success(MapToTicketDto(updatedTicket));
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        Ticket? ticket = await LoadTrackedTicketWithRelationsAsync(id);
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
            CreatedByUserId = ticket.CreatedByUserId,
            CreatedByUserName = ticket.CreatedByUser?.FullName ?? string.Empty,
            AssignedToUserId = ticket.AssignedToUserId,
            AssignedToUserName = ticket.AssignedToUser?.FullName ?? string.Empty,
            CreatedAt = ticket.CreatedAt
        };
    }

    private static TicketDetailDto MapToTicketDetailDto(Ticket ticket)
    {
        return new TicketDetailDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Status = ticket.Status,
            Priority = ticket.Priority,
            CategoryId = ticket.CategoryId,
            CategoryName = ticket.Category.Name,
            CreatedByUserId = ticket.CreatedByUserId,
            CreatedByUserName = ticket.CreatedByUser?.FullName ?? string.Empty,
            AssignedToUserId = ticket.AssignedToUserId,
            AssignedToUserName = ticket.AssignedToUser?.FullName ?? string.Empty,
            CreatedAt = ticket.CreatedAt,
            Comments = ticket.Comments
                .OrderBy(c => c.CreatedAt)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    TicketId = c.TicketId,
                    UserId = c.UserId,
                    UserRole = c.User.Role,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                })
                .ToList()
        };
    }

    private bool CanAccessTicket(Ticket ticket, int currentUserId, string currentUserRole)
    {
        if (currentUserRole == RoleNames.Admin || currentUserRole == RoleNames.Agent)
        {
            return true;
        }

        return ticket.CreatedByUserId == currentUserId;
    }


    private IQueryable<Ticket> BuildBaseTicketQuery()
    {
        return dbContext.Tickets
            .AsNoTracking()
            .Include(t => t.Category)
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedToUser);
    }

    private async Task<PagedResultDto<TicketDto>> CreatePagedResultAsync(IQueryable<Ticket> ticketsQuery, GetTicketsQueryDto query)
    {
        //1.Keresés
        string? normalizedSearchTerm = query.SearchTerm?.Trim();
        if (!string.IsNullOrWhiteSpace(normalizedSearchTerm))
        {
            string loweredSearchTerm = normalizedSearchTerm.ToLower();

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

            ("createdby", true) => ticketsQuery.OrderBy(t => t.CreatedByUser != null ? t.CreatedByUser.FullName : string.Empty),
            ("createdby", false) => ticketsQuery.OrderByDescending(t => t.CreatedByUser != null ? t.CreatedByUser.FullName : string.Empty),

            ("assignedto", true) => ticketsQuery.OrderBy(t => t.AssignedToUser != null ? t.AssignedToUser.FullName : string.Empty),
            ("assignedto", false) => ticketsQuery.OrderByDescending(t => t.AssignedToUser != null ? t.AssignedToUser.FullName : string.Empty),

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
                CreatedByUserId = t.CreatedByUserId,
                CreatedByUserName = t.CreatedByUser != null ? t.CreatedByUser.FullName : string.Empty,
                AssignedToUserId = t.AssignedToUserId,
                AssignedToUserName = t.AssignedToUser != null ? t.AssignedToUser.FullName : string.Empty,
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
            TotalPages = totalPages,
            HasPreviousPage = query.PageNumber > 1,
            HasNextPage = query.PageNumber < totalPages
        };
    }

    private async Task<Ticket?> LoadTrackedTicketWithRelationsAsync(int id)
    {
        return await dbContext.Tickets
            .Include(t => t.Category)
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedToUser)
            .Include(t => t.Comments)
            .ThenInclude(c => c.User)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}