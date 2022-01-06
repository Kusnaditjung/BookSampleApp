using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Domain;
using System.Reflection;

namespace Book.Persistence
{
	public class AppDbContext: DbContext
	{
		public DbSet<Domain.Book> Books { get; set;}
	//	public DbSet<Domain.Author> Author { get; set;}

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			modelBuilder.ApplyConfiguration(new Configuration.AddressConfiguration());
			modelBuilder.Entity<Book.Domain.Book>(b => b.HasOne(b => b.Address));


			base.OnModelCreating(modelBuilder);
		}

	}
}
