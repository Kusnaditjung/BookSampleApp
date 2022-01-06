using Book.Application.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Book.Application.EventHandlers
{
	public class BookDeletedEventHandlerOne : INotificationHandler<Events.BookDeletedEvent>
	{
		public Task Handle(BookDeletedEvent notification, CancellationToken cancellationToken)
		{
			Console.WriteLine("Event handler one");
			return Task.FromResult(0);
		}
	}
}
