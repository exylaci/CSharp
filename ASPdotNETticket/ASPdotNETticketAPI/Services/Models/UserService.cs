using ASPdotNETticketAPI.Constants;
using ASPdotNETticketAPI.Data;
using ASPdotNETticketAPI.Dtos.Users;
using ASPdotNETticketAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Services.Models;

public class UserService : IUserService
{
    private readonly AppDbContext dbContext;

    public UserService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<UserListItemDto>> GetActiveAgentsAsync()
    {
        return await dbContext.Users
            .AsNoTracking()
            .Where(u => u.IsActive && u.Role == RoleNames.Agent)    //logika: csak aktív Agent-hez lehet rendelni
            .OrderBy(u => u.FullName)
            .Select(u => new UserListItemDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role,
            })
            .ToListAsync();
    }
}