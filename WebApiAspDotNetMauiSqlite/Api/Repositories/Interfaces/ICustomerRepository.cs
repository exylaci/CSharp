using Api.Dtos.Results;
using Api.Entities;

namespace Api.Repositories.Interfaces;

public interface ICustomerRepository
{
    Task<List<CustomerEntity>> GetAllCustomersAsync();
    Task<CustomerEntity?> GetCustomerByEmailAsync(string email);
    Task<RepositoryResult<CustomerEntity>> CreateCustomerAsync(CustomerEntity customerEntity);
    Task<CustomerEntity?> UpdateCustomerAsync(string email, CustomerEntity customerEntity);
    Task<bool> DeleteCustomerAsync(string email);
}