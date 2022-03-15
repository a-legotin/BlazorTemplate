using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorTemplate.Shared.Models;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Email is required field")]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("first_name")]
    [Required(ErrorMessage = "Firstname is required field")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [Required(ErrorMessage = "Lastname is required field")]
    public string? LastName { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("mobile_phone")]
    public string? MobilePhone { get; set; }
}