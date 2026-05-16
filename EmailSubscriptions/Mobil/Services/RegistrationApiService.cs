using System.Net.Http.Json;
using System.Text.Json;
using Mobil.Dtos;
using Mobil.Services.Inerfaces;
using Mobil.Settings;

namespace Mobil.Services;

public class RegistrationApiService : IRegistrationApiService
{
    private readonly HttpClient _httpClient;

    public RegistrationApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<List<EmailAddressDto>> GetAllAsync()
    {
        List<EmailAddressDto>? result = await _httpClient.GetFromJsonAsync<List<EmailAddressDto>>("EmailSubscriptions");
        return result ?? new List<EmailAddressDto>();
    }

    public async Task<(bool Success, string Message)> CreateEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return (false, "Nincs email cím");
        }

        string normalizedEmail = email.Trim().ToLower();

        EmailAddressDto dto = new()
        {
            Email = normalizedEmail
        };

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("EmailSubscriptions", dto);
        return (response.IsSuccessStatusCode, response.IsSuccessStatusCode ? "Eltároltam" : "Nem sikerült eltárolni");
    }
}