using BlazorTemplate.Api.Context.Configuration;
using BlazorTemplate.Classes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorTemplate.Api.Context;

public class CustomerContext : IdentityDbContext<IdentityUser>
{
    public CustomerContext(DbContextOptions options)
        :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }

    public DbSet<Customer> Customers { get; set; } = null!;
}