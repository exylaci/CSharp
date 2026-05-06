using ASPdotNETticketAPI.Dtos.Comments;
using ASPdotNETticketAPI.Services.Models;

namespace ASPdotNETticketAPI.Services.Interfaces;

public interface ICommentService //A kommenteket kezelő végpontok "kiszolgálásához" kell szervíz is, ahhoz pedig egy interfész. Kommenteket létrehozni és listázni kell tudni.
{
    Task<ServiceResult<List<CommentDto>>> GetByTicketIdAsync(int ticketId, int currentUserId, string currentUserRole);
    Task<ServiceResult<CommentDto>> CreateAsync(int ticketId, CreateCommentDto dto, int currentUserId, string currentUserRole);
}