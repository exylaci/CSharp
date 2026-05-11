using System.Net.Http.Json;
using System.Text.Json;
using ASPdotNETticketMobile.Helpers;
using ASPdotNETticketMobile.Models.Auth;
using ASPdotNETticketMobile.Services.Interfaces;

namespace ASPdotNETticketMobile.Services.Models;

public class AuthService : IAuthService
{
    private readonly IApiClientFactory apiClientFactory;
    private readonly ITokenStorageService tokenStorageService;

    private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true  //Nem különbözteti meg a kis és a nagy betűket
    };

    public AuthService(IApiClientFactory apiClientFactory, ITokenStorageService tokenStorageService)
    {
        this.apiClientFactory = apiClientFactory;
        this.tokenStorageService = tokenStorageService;
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        HttpClient httpClient = apiClientFactory.CreateClient();

        HttpResponseMessage response = await httpClient.PostAsJsonAsync(ApiEndpoints.Login, request);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        string content = await response.Content.ReadAsStringAsync();
        AuthResponse? authResponse = JsonSerializer.Deserialize<AuthResponse>(content, jsonOptions);
        if (authResponse is null || string.IsNullOrWhiteSpace(authResponse.Token))
        {
            return null;
        }

        await tokenStorageService.SaveTokenAsync(authResponse.Token);
        await tokenStorageService.SaveUserDisplayDataAsync(authResponse.FullName, authResponse.Role);
        return authResponse;
    }

    public async Task LogoutAsync()
    {
        await tokenStorageService.ClearAllAsync();
    }

    public async Task<bool> IsLoggedInAsync()
    {
        string? token = await tokenStorageService.GetTokenAsync();
        return !string.IsNullOrEmpty(token);
    }

    public async Task<string?> GetCurrentUserNameAsync()
    {
        return await tokenStorageService.GetUserFullnameAsync();
    }

    public async Task<string?> GetCurrentUserRoleAsync()
    {
        return await tokenStorageService.GetUserRoleAsync();
    }
}