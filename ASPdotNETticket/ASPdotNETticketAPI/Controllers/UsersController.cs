using ASPdotNETticketAPI.Constants;
using ASPdotNETticketAPI.Dtos.Users;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPdotNETticketAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [Authorize(Roles = RoleNames.Admin + "," + RoleNames.Agent)]
    [HttpGet("agents")]
    public async Task<ActionResult<IEnumerable<UserListItemDto>>> GetAgents()
    {
        List<UserListItemDto> agents = await userService.GetActiveAgentsAsync();
        return Ok(agents);
    }
}