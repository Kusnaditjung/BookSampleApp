using System.Collections.Generic;

namespace Book.Domain
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public Author Author { get; set; }

		public Address Address { get; set; }
	}
}