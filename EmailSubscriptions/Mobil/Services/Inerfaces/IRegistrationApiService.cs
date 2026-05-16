using Mobil.Dtos;

namespace Mobil.Services.Inerfaces;

public interface IRegistrationApiService
{
    Task<List<EmailAddressDto>> GetAllAsync();
    Task<(bool Success, string Message)> CreateEmailAsync(string email);
}