using System.Net.Http.Headers;
using ASPdotNETticketMobile.Services.Interfaces;
using ASPdotNETticketMobile.Settings;

namespace ASPdotNETticketMobile.Services.Models;

public class ApiClientFactory : IApiClientFactory
{
    private readonly ITokenStorageService tokenStorageService;

    public ApiClientFactory(ITokenStorageService tokenStorageService)
    {
        this.tokenStorageService = tokenStorageService;
    }

    public HttpClient CreateClient()
    {
        return new HttpClient
        {
            BaseAddress = new Uri(AppSettings.BaseApiUrl),
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    public async Task<HttpClient> CreateAuthenticatedClientAsync()
    {
        HttpClient client = CreateClient();
        string? token = await tokenStorageService.GetTokenAsync();
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return client;
    }
}