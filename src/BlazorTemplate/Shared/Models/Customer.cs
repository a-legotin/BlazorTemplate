using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorTemplate.Shared.Models;

public class Customer
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required field")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required field")]
    public string? Email { get; set; }

}

public class CustomerPoco
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("mobile_phone")]
    public string? MobilePhone { get; set; }

}