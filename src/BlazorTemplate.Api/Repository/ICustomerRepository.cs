using BlazorTemplate.Classes.Models;

namespace BlazorTemplate.Api.Repository;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetCustomers();
}