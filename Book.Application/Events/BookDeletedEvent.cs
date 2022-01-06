using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Events
{
	public class BookDeletedEvent : INotification
	{
		public int BookdId { get; set; }
	}
}
