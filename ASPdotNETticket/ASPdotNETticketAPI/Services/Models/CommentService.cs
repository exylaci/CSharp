using ASPdotNETticketAPI.Constants;
using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Comments;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Enums;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Services.Models;

public class CommentService : ICommentService
{
    private readonly AppDbContext dbContext;

    public CommentService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ServiceResult<List<CommentDto>>> GetByTicketIdAsync(int ticketId, int currentUserId, string currentUserRole)
    {
        Ticket? ticket = await dbContext.Tickets
            .AsNoTracking() //csak olvassuk
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedToUser)
            .FirstOrDefaultAsync(t => t.Id == ticketId);

        if (ticket is null)
        {
            return ServiceResult<List<CommentDto>>.NotFound($"A {ticketId} azonosítójú tiket nem található!");
        }

        if (!CanAccesTicket(ticket, currentUserId, currentUserRole))
        {
            return ServiceResult<List<CommentDto>>.NotFound($"A {ticketId} azonosítójú tiket nem található!");
        }

        List<CommentDto> comments = await dbContext.TicketComments
            .AsNoTracking()
            .Include(c => c.User)
            .Where(c => c.TicketId == ticketId)
            .OrderBy(c => c.CreatedAt)
            .Select(c => new CommentDto
            {
                Id = c.Id,
                TicketId = c.TicketId,
                UserId = c.UserId,
                UserFullName = c.User.FullName,
                UserRole = c.User.Role,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            }).ToListAsync();
        return ServiceResult<List<CommentDto>>.Success(comments);
    }


    public async Task<ServiceResult<CommentDto>> CreateAsync(int ticketId, CreateCommentDto dto, int currentUserId, string currentUserRole)
    {
        Ticket? ticket = await dbContext.Tickets
            .AsNoTracking()
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedToUser)
            .FirstOrDefaultAsync(t => t.Id == ticketId);

        if (ticket == null)
        {
            return ServiceResult<CommentDto>.NotFound($"A {ticketId} azonosítójú tiket nem található!");
        }

        if (!CanAccesTicket(ticket, currentUserId, currentUserRole))
        {
            return ServiceResult<CommentDto>.NotFound($"A {ticketId} azonosítójú tiket nem található!");
        }

        if (ticket.Status == TicketStatus.Closed)
        {
            return ServiceResult<CommentDto>.Validation(nameof(ticket.Status), "Lezárt ticket nem lehet új kommentet felvenni");
        }

        AppUser? user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == currentUserId && u.IsActive);
        if (user is null)
        {
            return ServiceResult<CommentDto>.Validation("user", "Nincs vagy inaktív a user");
        }

        string normalizedContent = dto.Content.Trim();

        TicketComment comment = new TicketComment
        {
            TicketId = ticketId,
            UserId = user.Id,
            Content = normalizedContent,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.TicketComments.Add(comment);
        await dbContext.SaveChangesAsync();

        TicketComment createdComment = await dbContext.TicketComments
            .AsNoTracking()
            .Include(c => c.User)
            .FirstAsync(t => t.Id == comment.Id);

        return ServiceResult<CommentDto>.Success(new CommentDto
        {
            Id = createdComment.Id,
            TicketId = createdComment.TicketId,
            UserId = createdComment.UserId,
            UserFullName = createdComment.User.FullName,
            UserRole = createdComment.User.Role,
            Content = createdComment.Content,
            CreatedAt = createdComment.CreatedAt
        });
    }

    private bool CanAccesTicket(Ticket ticket, int currentUserId, string currentUserRole)
    {
        if (currentUserRole == RoleNames.Admin || currentUserRole == RoleNames.Agent)
        {
            return true;
        }

        return ticket.CreatedByUserId == currentUserId;
    }
}