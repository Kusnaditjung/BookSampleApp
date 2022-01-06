using System.Collections.Generic;

namespace Book.Domain
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public IEnumerable<Book> Books { get; set; }		
	}
}