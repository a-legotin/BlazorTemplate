using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorTemplate.Shared.Models;
using BlazorTemplate.Client.Abstractions;

namespace BlazorTemplate.Client.HttpRepository;

public class CustomerHttpRepository : ICustomerHttpRepository
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public CustomerHttpRepository(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        var response = await _client.GetAsync("customers");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        return JsonSerializer.Deserialize<List<Customer>>(content, _options);
    }
}