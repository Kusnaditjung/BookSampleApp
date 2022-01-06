using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Api
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class Header
	{
		private readonly RequestDelegate _next;

		public Header(RequestDelegate next)
		{
			_next = next;
		}

		public Task Invoke(HttpContext httpContext)
		{
			String id = Guid.NewGuid().ToString();
			httpContext.Request.Headers.Add("ConversationId", id);
			httpContext.Request.Headers.Add("RequestId", httpContext.TraceIdentifier);
			var res = _next(httpContext);
			//httpContext.Response.Headers.Add("ConversationGuid", id);
			//httpContext.Response.Headers.Add("RequestId", httpContext.TraceIdentifier);
			return res;
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class HeaderExtensions
	{
		public static IApplicationBuilder UseHeader(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<Header>();
		}
	}
}
