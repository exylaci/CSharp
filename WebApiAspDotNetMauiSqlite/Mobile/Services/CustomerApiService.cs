using System.Net.Http.Json;
using Mobile.Dtos;
using Mobile.Services.Interfaces;

namespace Mobile.Services;

public class CustomerApiService : ICustomerApiService
{
    private readonly HttpClient _httpClient;

    public CustomerApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CustomerDto>?> GetAllCustomerAsync()
    {
        var response = await _httpClient.GetAsync("api/Customer");
        if (!response.IsSuccessStatusCode) //Külön kell vizsgálni, különben a GetFromJsonAsync automatikusan kivételt dob sikertelen Http státuszkód (pl: 404) esetén.
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<List<CustomerDto>>();
    }

    public async Task<CustomerDto?> GetCustomerByEmailAsync(string email)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"api/Customer/{Uri.EscapeDataString(email)}");   //Uri.EscapeDataString() a speciális karaktereket URL encodolja. Pl: teszt@gmail.com → teszt%40gmail.com
        if (!response.IsSuccessStatusCode)  //Külön kell vizsgálni, különben a GetFromJsonAsync automatikusan 404-et dob
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<CustomerDto>();
    }

    public async Task<bool> CreateCustomerAsync(CustomerDto customerDto)
    {
        return (await _httpClient.PostAsJsonAsync("api/Customer", customerDto)).IsSuccessStatusCode;
    }

    public async Task<CustomerDto?> ModifyCustomerAsync(string email, CustomerDto customerDto)
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/Customer/{Uri.EscapeDataString(email)}", customerDto);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<CustomerDto>();
    }

    public async Task<bool> DeleteCustomerAsync(string email)
    {
        return (await _httpClient.DeleteAsync($"api/Customer/{Uri.EscapeDataString(email)}")).IsSuccessStatusCode;
    }
}