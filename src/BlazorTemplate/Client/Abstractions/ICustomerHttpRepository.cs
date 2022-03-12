using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTemplate.Shared.Models;

namespace BlazorTemplate.Client.Abstractions;

public interface ICustomerHttpRepository
{
    Task<IEnumerable<Customer>> GetCustomers();
}