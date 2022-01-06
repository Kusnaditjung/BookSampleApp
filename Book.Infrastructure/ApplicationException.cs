using System;

namespace Book.Infrastructure
{
	public class ApplicationException : Exception
	{
		public ApplicationException() : base() { }

		public ApplicationException(string message) : base(message) { }

		public ApplicationException(string message, Exception ex) : base(message, ex) { }
	}
}
