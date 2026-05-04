using ASPdotNETticketAPI.Dtos.Users;

namespace ASPdotNETticketAPI.Services.Interfaces;

public interface IUserService //hogy lehessen tudni, konkrétan kihez rendeli hozzá
{
    Task<List<UserListItemDto>> GetActiveAgentsAsync();
}