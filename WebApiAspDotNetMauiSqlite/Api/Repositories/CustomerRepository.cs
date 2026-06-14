using Api.Data;
using Api.Dtos.Results;
using Api.Entities;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerEntity>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<CustomerEntity?> GetCustomerByEmailAsync(string email)
    {
        CustomerEntity? entity = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        return entity;
    }

    public async Task<RepositoryResult<CustomerEntity>> CreateCustomerAsync(CustomerEntity customerEntity)
    {
        try
        {
            _context.Customers.Add(customerEntity);
            int rows = await _context.SaveChangesAsync();
            if (rows == 0)
            {
                return new RepositoryResult<CustomerEntity>
                {
                    Success = false,
                    ErrorCode = RepositoryErrorCode.DatabaseError,
                    ErrorMessage = "Az adatbázisba Nem került be."
                };
            }

            CustomerEntity? entity = await _context.Customers.FirstOrDefaultAsync(c => c.Email == customerEntity.Email);
            return new RepositoryResult<CustomerEntity>() { Success = true, Data = entity }; //async miatt a return értékét automatikusan becsomagolja Task<> -ba
        }
        catch (DbUpdateException ex) //Ez hogyan következok a duplikált kulcs hibából?
        {
            return new RepositoryResult<CustomerEntity>
            {
                Success = false,
                ErrorCode = RepositoryErrorCode.DatabaseError,
                ErrorMessage = ex.Message
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<CustomerEntity>
            {
                Success = false,
                ErrorCode = RepositoryErrorCode.UnknownError,
                ErrorMessage = ex.Message
            };
        }
    }

    public async Task<CustomerEntity?> UpdateCustomerAsync(string email, CustomerEntity customerEntity)
    {
        CustomerEntity? entity = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        if (entity is null)
        {
            return null;
        }

        entity.Email = customerEntity.Email;
        int piecesModified = await _context.SaveChangesAsync();
        if (piecesModified < 1)
        {
            return null;
        }

        return entity;
    }

    public async Task<bool> DeleteCustomerAsync(string email)
    {
        CustomerEntity? entity = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        if (entity is null)
        {
            return false;
        }

        _context.Customers.Remove(entity);
        int piecesModified = await _context.SaveChangesAsync();
        return piecesModified > 0;
    }
}