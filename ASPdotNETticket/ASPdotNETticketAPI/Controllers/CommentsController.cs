using System.Security.Claims;
using ASPdotNETticketAPI.Dtos.Comments;
using ASPdotNETticketAPI.Services.Interfaces;
using ASPdotNETticketAPI.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPdotNETticketAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/ticket/{ticketId:int}/comments")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService commentService;

    public CommentsController(ICommentService commentService)
    {
        this.commentService = commentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetByTicketId(int ticketId)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return NotFound(new { message = $"A nem tartalmaz érvényes felhasználót." });
        }


        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<List<CommentDto>> result = await commentService.GetByTicketIdAsync(ticketId, currentUserId, currentUserRole);
        if (result.IsNotFound)
        {
            return NotFound(new { message = result.Message });
        }

        return Ok(result.Data);
    }


    [HttpPost]
    public async Task<ActionResult<CommentDto>> Create(int ticketId, [FromBody] CreateCommentDto dto)
    {
        if (!TryGetCurrentUserId(out int currentUserId))
        {
            return NotFound(new { message = $"A nem tartalmaz érvényes felhasználót." });
        }


        string? currentUserRole = GetCurrentUserRole();
        if (string.IsNullOrWhiteSpace(currentUserRole))
        {
            return Unauthorized(new { message = $"A nem tartalmaz érvényes szerepkört." });
        }

        ServiceResult<CommentDto> result = await commentService.CreateAsync(ticketId, dto, currentUserId, currentUserRole);

        if (!result.IsSuccess)
        {
            return CreateActionResultFromServiceResult(result);
        }

        return StatusCode(StatusCodes.Status201Created, result.Data);
    }

    private ActionResult<CommentDto> CreateActionResultFromServiceResult(ServiceResult<CommentDto> result)
    {
        if (result.IsNotFound)
        {
            return NotFound(new { message = result.Message });
        }

        return Ok(result.Data);
    }


    private bool TryGetCurrentUserId(out int id)
    {
        string userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return int.TryParse(userIdClaim, out id);
    }

    private string? GetCurrentUserRole()
    {
        return User.FindFirstValue(ClaimTypes.Role);
    }
}