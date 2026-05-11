namespace ASPdotNETticketMobile.Services.Interfaces;

public interface ITokenStorageService   //A token eltárolására, és mindenre ami a token kezelésével kapcsolatos.
{
    Task SaveTokenAsync(string token);
    Task<string?> GetTokenAsync();
    Task RemoveTokenAsync();
    Task SaveUserDisplayDataAsync(string fullname, string role);
    Task<string?> GetUserFullnameAsync();
    Task<string?> GetUserRoleAsync();
    Task ClearAllAsync();
}