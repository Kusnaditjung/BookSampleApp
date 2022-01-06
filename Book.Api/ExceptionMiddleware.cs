using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book.Api
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IExcept except;
		private readonly ILogger<ExceptionMiddleware> logger;

		public ExceptionMiddleware(RequestDelegate next, IExcept except, ILogger<ExceptionMiddleware> logger)
		{
			_next = next;
			this.except = except;
			this.logger = logger;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch(Exception ex)
			{
				var response = httpContext.Response;
				if (ex is ApplicationException)
				{
					httpContext.Response.StatusCode = 400;
					response.ContentType = "application/json";
					await response.WriteAsJsonAsync(new { message = ex.Message });
				}
				else
				{
					httpContext.Response.StatusCode = 500;
					response.ContentType = "application/json";
					await response.WriteAsJsonAsync(new { message = "dangeours" });

				}
				logger.LogError(ex, $"RequestId = {httpContext.Response.Headers["RequestId"]}. Exception Message = {ex.Message}");
			}
		}


	}

	public static class ServiceExtensions
	{
		public static IServiceCollection AddExceptionMiddleware(this IServiceCollection service, string opsi)
		{
			service.AddSingleton<IExcept>(new Except(opsi));
			return service;
		}
	}

	public interface IExcept
	{
		public string Contoh { get; }
	}

	public class Except : IExcept
	{
		private readonly string opsi;
		public Except(string opti) { opsi = opti; }
		public string Contoh { get { return opsi;  } }
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class ExceptionMiddlewareExtensions
	{
		public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ExceptionMiddleware>();
		}
	}
}
