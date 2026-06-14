using Api.Dtos;
using Api.Dtos.Results;

namespace Api.Services.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto?> GetCustomerByEmailAsync(string email);
    Task<ServiceResult<CustomerDto>> CreateCustomerAsync(CustomerDto customerDto);
    Task<CustomerDto?> UpdateCustomerAsync(string email, CustomerDto customerDto);
    Task<bool> DeleteCustomerAsync(string email);
}