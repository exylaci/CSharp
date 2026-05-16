using Api.Dtos;

namespace Api.Services.Interfaces;

public interface IEmailSubscriptionService
{
    Task<List<EmailAddressDto>> GetAllAsync();
    Task<(bool Success, string Message)> CreateAsync(EmailAddressDto dto);
}