using BlazorTemplate.Api.Abstractions;
using BlazorTemplate.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTemplate.Api.Controllers;

[Route("api/customers")]
[ApiController]
[Authorize]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _repo;

    public CustomersController(ICustomerRepository repo)
    {
        _repo = repo;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _repo.GetCustomers();
        return Ok(products);
    }
}
