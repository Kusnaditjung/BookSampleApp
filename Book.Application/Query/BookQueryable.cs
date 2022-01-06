using Book.Domain;
using Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;

namespace Book.Application.Query
{
	public class BookQueryable : IBookQueryable, IDisposable
	{
		private readonly AppDbContext context;		
		private readonly DbConnection connection;

		public BookQueryable(AppDbContext context, DbConnection connection )
		{
			this.context = context;
			
			this.connection = connection;
		}
		public IQueryable<Book.Domain.Book> Books
		{
			get
			{
				Console.WriteLine("query " + context.ContextId.InstanceId);
				return context.Books;
			//	return GetBook().AsQueryable();
			}
		}

		public IEnumerable<Book.Domain.Book> GetBook()
		{
			using (var command = new SqlCommand("select * from dbo.Books", (SqlConnection) connection))
			{
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{

					if (reader.HasRows)
					{
						while (reader.Read())
						{
							var book = new Book.Domain.Book();
							book.Id = reader.GetInt32(0);
							book.Title = reader.GetString(1);
							book.Year = reader.GetInt32(2);

							yield return book;
						}
					}
				

					yield break;
				}
			}
		}

		public IQueryable<Author> Author => throw new NotImplementedException();

		public void Dispose()
		{
			context.Dispose();
			connection.Dispose();
			
			GC.SuppressFinalize(this);
		}
	}
}
