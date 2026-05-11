namespace ASPdotNETticketMobile.Services.Interfaces;

public interface IApiClientFactory  //Hogy közös base URL-t lehessen használni a teljes alkalmazáson belül.
{
    HttpClient CreateClient();
    Task<HttpClient> CreateAuthenticatedClientAsync();
}