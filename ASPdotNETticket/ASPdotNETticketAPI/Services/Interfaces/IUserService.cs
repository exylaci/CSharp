using ASPdotNETticketAPI.Dtos.Users;

namespace ASPdotNETticketAPI.Services.Interfaces;

public interface IUserService
{
    Task<List<UserListItemDto>> GetActiveAgentsAsync();
}