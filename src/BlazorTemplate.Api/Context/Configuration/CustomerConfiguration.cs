using BlazorTemplate.Classes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorTemplate.Api.Context.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.HasData
		(
			new Customer
			{
				Id = new Guid("0102F709-1DD7-40DE-AF3D-23598C6BBD1F"),
				Name = "Vasili Pushkin",
				Email = "vasya@pushkin.io"
			}
		);
	}
}