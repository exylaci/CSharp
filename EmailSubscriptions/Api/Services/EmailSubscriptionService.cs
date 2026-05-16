using Api.Data;
using Api.Dtos;
using Api.Entities;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class EmailSubscriptionService : IEmailSubscriptionService
{
    private readonly AppDbContext _dbContext;

    public EmailSubscriptionService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<EmailAddressDto>> GetAllAsync()
    {
        return await _dbContext.EmailAdresses
            .OrderBy(e => e.Email)
            .Select(n => new EmailAddressDto
            {
                Email = n.Email,
            })
            .ToListAsync();
    }

    public async Task<(bool Success, string Message)> CreateAsync(EmailAddressDto dto)
    {
        string email = dto.Email.Trim().ToLower();
        bool exists = await _dbContext.EmailAdresses
            .AnyAsync(x => x.Email.ToLower() == email);
        if (exists)
        {
            return (false, "Ez az email már létezik.");
        }

        EmailAdrdess entity = new()
        {
            Email = email
        };
        _dbContext.EmailAdresses.Add(entity);
        await _dbContext.SaveChangesAsync();
        return (true, "Sikeres mentés.");
    }
}