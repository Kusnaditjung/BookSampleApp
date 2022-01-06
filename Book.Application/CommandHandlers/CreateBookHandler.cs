using AutoMapper;
using Book.Application.Commands;
using Book.Application.Dto;
using Book.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Book.Application.Handlers
{
	public class CreateBookHandler : IRequestHandler<Commands.CreateBookCommand, Dto.BookDto>
	{

		public CreateBookHandler(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		private AppDbContext _context;
		private readonly IMapper _mapper;

		public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			var book = _mapper.Map<Book.Domain.Book>(request.newBook);

			_context.Books.Add(book);

			await  _context.SaveChangesAsync();

			return _mapper.Map<BookDto>(book);
		}
	}
}
