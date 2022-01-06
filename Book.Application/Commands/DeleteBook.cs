using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Commands
{
	public class DeleteBook : IRequest
	{
		public int deletedBookId { get; set; }
	}
}
