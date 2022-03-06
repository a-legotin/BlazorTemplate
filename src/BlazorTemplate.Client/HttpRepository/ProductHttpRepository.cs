using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorTemplate.Classes.Models;
using BlazorTemplate.Classes.RequestFeatures;
using BlazorTemplate.Client.Features;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorTemplate.Client.HttpRepository;

public class ProductHttpRepository : IProductHttpRepository
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public ProductHttpRepository(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<Customer>> GetProducts()
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