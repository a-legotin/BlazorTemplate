using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTemplate.Classes.Models;
using BlazorTemplate.Classes.RequestFeatures;
using BlazorTemplate.Client.Features;

namespace BlazorTemplate.Client.HttpRepository;

public interface IProductHttpRepository
{
    Task<IEnumerable<Customer>> GetProducts();
}