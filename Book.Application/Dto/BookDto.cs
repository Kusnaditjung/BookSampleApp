using System;
using System.Collections.Generic;

namespace Book.Application.Dto
{
	public class BookDto
	{
		public int Id { get; set; }	
		public String Title { get; set; }	
		public int Year { get; set; }
		public AuthorDto Author { get; set; }


		public AddressDto Address { get; set; }

	}
}
