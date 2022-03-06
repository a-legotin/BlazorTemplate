using BlazorTemplate.Api.Context;
using BlazorTemplate.Classes.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTemplate.Api.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerContext _context;

    public CustomerRepository(CustomerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }
}