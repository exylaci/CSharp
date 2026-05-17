using Api.Dtos;
using Api.Entities;
using Api.Repositories.Interfaces;
using Api.Services.Interfaces;

namespace Api.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository) // DI -ben kapja az adatbázis elérési réteghez a kapcsolatot, bővíthetőség miatt interfész típust
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync() //Mert a frontend ha nem C#-ban íródott, akkor nem feltétlenül List-nek hívják a listát.
    {
        List<CustomerEntity> entities = await _repository.GetAllCustomersAsync();
        List<CustomerDto> dtos = entities.Select(e => new CustomerDto
        {
            Email = e.Email
        }).ToList();
        return dtos;
    }

    public async Task<CustomerDto?> GetCustomerByEmailAsync(string email)
    {
        CustomerEntity? entity = await _repository.GetCustomerByEmailAsync(email);
        if (entity == null)
        {
            return null;
        }

        return new CustomerDto { Email = entity.Email };
    }

    public async Task<CustomerDto?> CreateCustomerAsync(CustomerDto customerDto)
    {
        CustomerEntity? entity = await _repository.GetCustomerByEmailAsync(customerDto.Email);
        if (entity != null)
        {
            return null; //Már van ilyen, nem menti el 2 példányban
        }

        CustomerEntity? newEntity = await _repository.CreateCustomerAsync(new CustomerEntity { Email = customerDto.Email });
        if (newEntity is null)
        {
            return null; //nem sikerült elmenteni
        }

        return new CustomerDto { Email = newEntity.Email };
    }

    public async Task<CustomerDto?> UpdateCustomerAsync(string email, CustomerDto customerDto)
    {
        CustomerEntity? entity = await _repository.GetCustomerByEmailAsync(email);
        if (entity is null)
        {
            return null; //nincs ilyen, nem tudja updatelni
        }

        CustomerEntity? newEntity = await _repository.UpdateCustomerAsync(email, new CustomerEntity { Email = customerDto.Email });
        if (newEntity is null)
        {
            return null; //nem sikerült az update
        }

        return new CustomerDto { Email = newEntity.Email };
    }

    public async Task<bool> DeleteCustomerAsync(string email)
    {
        CustomerEntity? entity = await _repository.GetCustomerByEmailAsync(email);
        if (entity is null)
        {
            return false; //nincs ilyen, nem tudja törölni
        }

        await _repository.DeleteCustomerAsync(email);
        CustomerEntity? deletedEntity = await _repository.GetCustomerByEmailAsync(email);
        return deletedEntity is null;
    }
}