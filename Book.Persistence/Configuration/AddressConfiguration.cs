using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Persistence.Configuration
{
	public class AddressConfiguration : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.ToTable("Address")
				.Property<int>("Id")   
					.IsRequired();

			builder.HasKey("Id");
		}
	}
}
