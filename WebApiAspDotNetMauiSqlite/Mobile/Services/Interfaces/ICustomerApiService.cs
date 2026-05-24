using Mobile.Dtos;

namespace Mobile.Services.Interfaces;

public interface ICustomerApiService
{
    Task<List<CustomerDto>?> GetAllCustomerAsync(); //Összes listázása
    Task<CustomerDto?> GetCustomerByEmailAsync(string email); //Egy adatai lekérdezése 
    Task<bool> CreateCustomerAsync(CustomerDto customerDto); //Új létrehozása/hozzáadása a listához
    Task<CustomerDto?> ModifyCustomerAsync(string email, CustomerDto customerDto); //Egy adatai módosítása
    Task<bool> DeleteCustomerAsync(string email); //Egy törlése
}