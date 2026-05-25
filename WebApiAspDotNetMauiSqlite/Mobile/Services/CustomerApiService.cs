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
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Customer");
            if (!response.IsSuccessStatusCode) //Külön kell vizsgálni, különben a GetFromJsonAsync automatikusan kivételt dob sikertelen Http státuszkód (pl: 404) esetén.
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<List<CustomerDto>>();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<CustomerDto?> GetCustomerByEmailAsync(string email)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Customer/{Uri.EscapeDataString(email)}"); //Uri.EscapeDataString() a speciális karaktereket URL encodolja. Pl: teszt@gmail.com → teszt%40gmail.com
            if (!response.IsSuccessStatusCode) //Külön kell vizsgálni, különben a GetFromJsonAsync automatikusan 404-et dob
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<CustomerDto>();
        }
        catch (Exception) //Ha nem elérhető a backend, kivételt dob a GetAsync()
        {
            return null;
        }
    }

    public async Task<bool> CreateCustomerAsync(CustomerDto customerDto)
    {
        try
        {
            return (await _httpClient.PostAsJsonAsync("api/Customer", customerDto)).IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<CustomerDto?> ModifyCustomerAsync(string email, CustomerDto customerDto)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/Customer/{Uri.EscapeDataString(email)}", customerDto);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<CustomerDto>();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> DeleteCustomerAsync(string email)
    {
        try
        {
            return (await _httpClient.DeleteAsync($"api/Customer/{Uri.EscapeDataString(email)}")).IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }
}