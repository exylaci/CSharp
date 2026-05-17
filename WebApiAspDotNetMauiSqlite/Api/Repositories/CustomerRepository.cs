using Api.Data;
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

    public async Task<CustomerEntity?> CreateCustomerAsync(CustomerEntity customerEntity)
    {
        await _context.Customers.AddAsync(customerEntity);
        _context.SaveChanges();
        CustomerEntity? entity = await _context.Customers.FirstOrDefaultAsync(c => c.Email == customerEntity.Email);
        return entity; //async miatt a return értékét automatikusan becsomagolja Task<> -ba
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