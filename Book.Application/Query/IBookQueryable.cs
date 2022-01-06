using System.Linq;

namespace Book.Application.Query
{
	public interface IBookQueryable
	{
		IQueryable<Domain.Book> Books { get; }
		IQueryable<Domain.Author> Author { get; }
	}
}