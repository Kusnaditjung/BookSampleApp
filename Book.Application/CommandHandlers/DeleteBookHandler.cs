using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Book.Application.Commands;
using Book.Application.Dto;
using Book.Persistence;
using MediatR;

namespace Book.Application.Handlers
{
	public class DeleteBookHandler : IRequestHandler<DeleteBook>
	{
		private AppDbContext context;
		private readonly IMapper mapper;
		private readonly IMediator _mediator;
		public DeleteBookHandler(AppDbContext context, IMapper mapper, IMediator mediator)
		{
			this.context = context;
			this.mapper = mapper;
			this._mediator = mediator;
		}

		public async Task<Unit> Handle(DeleteBook request, CancellationToken cancellationToken)
		{
			var book = context.Books.Find(request.deletedBookId);

			context.Books.Remove(book);

			await context.SaveChangesAsync(default);

			await  _mediator.Publish(new Events.BookDeletedEvent { BookdId = request.deletedBookId });

			Console.WriteLine(context.ContextId.InstanceId);
			context.Dispose();
			return Unit.Value;
		}
	}
}
