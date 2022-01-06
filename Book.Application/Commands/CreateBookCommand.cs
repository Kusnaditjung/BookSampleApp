using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Book.Application.Commands
{
	public class CreateBookCommand: IRequest<Dto.BookDto>
	{
		public Dto.BookDto newBook { get; set; }
	}
}
