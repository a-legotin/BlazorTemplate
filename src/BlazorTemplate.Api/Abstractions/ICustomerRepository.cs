using BlazorTemplate.Classes.Models;

namespace BlazorTemplate.Api.Abstractions;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetCustomers();
}