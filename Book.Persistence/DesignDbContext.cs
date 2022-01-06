using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Book.Persistence
{
	public class DesignDbContext : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<AppDbContext>();
			builder.UseSqlServer("Server=localhost;Database=gf;Trusted_Connection=true");

			return new AppDbContext(builder.Options);
		}
	}
}
