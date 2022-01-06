using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Book.Api.Filters
{
	public class ExceptionFilter : IExceptionFilter
	{
		
		public void OnException(ExceptionContext context)
		{
			Exception exception = context.Exception;
			var objResult = new ObjectResult(new { errorMessage = exception.Message });
			context.Result = objResult;

		}
	}
}
