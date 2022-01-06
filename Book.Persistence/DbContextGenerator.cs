using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Book.Persistence
{
	public class DbContextGenerator
	{
		public static void Initialize(AppDbContext context)
		{
			context.Database.Migrate();

			if (context.Books.AnyAsync().Result) return;

			SeeData(context);
		}

		public static void SeeData(AppDbContext context)
		{			
			var authors = new List<Book.Domain.Author>
			{
				new Domain.Author{Name = "Kusnadi"},
				new Domain.Author{Name = "Movie"},
				new Domain.Author{Name = "Terry"},
				new Domain.Author{Name = "Rudy susanto"}
			};


			

			var books = new List<Book.Domain.Book>
			{
				new Domain.Book{Title = "Wake up", Year = 1994, Author = authors[0], Address = new Domain.Address{Street = "Court", City = "Leeds" } },
				new Domain.Book{Title = "Sunshine", Year = 1998, Author = authors[0], Address = new Domain.Address{Street = "Court2", City = "Machester" }  },
				new Domain.Book{Title = "Math A", Year = 1995, Author = authors[1]   },
				new Domain.Book{Title = "Math B", Year = 1997,  Author = authors[1] },
				new Domain.Book{Title = "Geometry A", Year = 1997,  Author = authors[1] },
				new Domain.Book{Title = "Fiction 1", Year = 1990,  Author = authors[2] },
				new Domain.Book{Title = "Martingale 2", Year = 1991,  Author = authors[3]}
			};

		//	context.Author.AddRange(authors);
			context.Books.AddRange(books);
		

			context.SaveChanges();
		}
	}
}
