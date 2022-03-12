using System.ComponentModel.DataAnnotations;

namespace BlazorTemplate.Shared.Models;

public class Customer
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required field")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required field")]
    public string? Email { get; set; }

}