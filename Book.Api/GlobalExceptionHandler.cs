/*using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Book.Api
{
	public class GlobalExceptionHandler : IGlobalExceptionHandler
	{
		public async Task Handle(HttpContext context)
		{
			Exception exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
		

			if (exception == null)
			{
				await context.Response.WriteAsJsonAsync(new { error = "Unknown exception" });
			}
			else
			{
			//	_logger.LogError(exception, exception.Message);

				
					await context.Response.WriteAsJsonAsync(new { error = $"RequestId = {context.Request.Headers["RequestId"]}, Exception message = {exception.Message}" });
				

			}

		


		}

		public static bool IsBool()
		{
			return false;
		}
	}
}
*/