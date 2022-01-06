using Book.Application.Dto;
using Book.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSolution.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BookController : ControllerBase
	{

		private readonly BookService bookService;

		private readonly IMediator _mediator;
		public BookController(BookService bookService, IMediator mediator)
		{
			this.bookService = bookService;
			this._mediator = mediator;
		}

		[HttpPost]
		public async Task<BookDto> CreateBook([FromBody] BookDto bookDto)
		{

			var createdCommand = new Book.Application.Commands.CreateBookCommand { newBook = bookDto };

			var book = await _mediator.Send(createdCommand);

			return book;
		}

		[HttpGet]
	//	[Authorize]
		public async Task<IEnumerable<BookDto>> GetAllBooks([FromQuery] string author = null) 
		{
		
			return await bookService.GetBookByAuthor(author); 
		}

		[HttpGet]
		[Route("{bookId:int}")]
		public async Task<IEnumerable<BookDto>> GetBookById(int bookId) => await bookService.GetBookById(bookId);


		


		[HttpDelete]
		[Route("{bookId:int}")]
		public async Task<IActionResult> DeleteBook(int bookId) {

			var deleteCommand = new Book.Application.Commands.DeleteBook { deletedBookId = bookId };

			 await _mediator.Send(deleteCommand);
			return new OkResult();
		} 



	}
}
