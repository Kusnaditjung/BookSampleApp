using AutoMapper;
using Book.Application.Dto;
using Book.Application.Query;
using Book.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Book.Application.Services
{
 
	public class BookService
	{
		private readonly IBookQueryable queryable;
		private readonly IMapper mapper;
		public BookService(IBookQueryable queryable, IMapper mapper)
		{
			this.queryable = queryable;
			this.mapper = mapper;
		}

		public async Task<IReadOnlyCollection<BookDto>> GetAllBook() =>		
			await queryable
				.Books
				.Select(book => mapper.Map<BookDto>(book))
				.ToListAsync();		

		public async Task<IReadOnlyCollection<BookDto>> GetBookById(int bookId) =>		
			await queryable
				.Books
				.Where(book => book.Id == bookId)
				.Select(book => mapper.Map<BookDto>(book))
				.ToListAsync();

		public async Task<IReadOnlyCollection<BookDto>> GetBookByAuthor(string authorName)
		{					

			var allBooks = queryable
				.Books
				.Include(book => book.Author)
				.Include(book => book.Address);

			if (!String.IsNullOrWhiteSpace(authorName))
			{
				return await allBooks
					.Where(book => book.Author != null && String.Equals(book.Author.Name, authorName, StringComparison.InvariantCultureIgnoreCase))
					.Select(book => mapper.Map<BookDto>(book))
					.ToListAsync();

			}

			return await allBooks
				.Select(book => mapper.Map<BookDto>(book))
				.ToListAsync();
		}
		
	}
}
