using ASPdotNETticketMobile.Services.Interfaces;
using ASPdotNETticketMobile.Settings;

namespace ASPdotNETticketMobile.Services.Models;

public class TokenStorageService : ITokenStorageService
{
    public async Task SaveTokenAsync(string token)
    {
        await SecureStorage.Default.SetAsync(AppSettings.AuthTokenKey, token); //Biztongágos (secured) storage-ben tároljuk a tokent, mint minden más érzékeny és sensitive információt
    }

    public async Task<string?> GetTokenAsync()
    {
        return await SecureStorage.Default.GetAsync(AppSettings.AuthTokenKey);
    }

    public Task RemoveTokenAsync()
    {
        SecureStorage.Default.Remove(AppSettings.AuthTokenKey);
        return Task.CompletedTask;
    }

    public async Task SaveUserDisplayDataAsync(string fullname, string role)
    {
        await SecureStorage.Default.SetAsync(AppSettings.CurrentUserNameKey, fullname);
        await SecureStorage.Default.SetAsync(AppSettings.CurrentUserNameKey, role);
    }

    public async Task<string?> GetUserFullnameAsync()
    {
        return await SecureStorage.Default.GetAsync(AppSettings.CurrentUserNameKey);
    }

    public async Task<string?> GetUserRoleAsync()
    {
        return await SecureStorage.Default.GetAsync(AppSettings.CurrentUserRoleKey);
    }

    public async Task ClearAllAsync()
    {
        SecureStorage.Default.Remove(AppSettings.AuthTokenKey);
        SecureStorage.Default.Remove(AppSettings.CurrentUserNameKey);
        SecureStorage.Default.Remove(AppSettings.CurrentUserRoleKey);
        await Task.CompletedTask;
    }
}