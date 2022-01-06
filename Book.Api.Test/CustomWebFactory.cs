using Book.Api.Authentication;
using Book.Application.Mappers;
using Book.Application.Services;
using Book.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Book.Api.Test
{
	public class CustomWebFactory : WebApplicationFactory<BookSolution.Startup>
	{
		////protected override void ConfigureWebHost(IWebHostBuilder builder)
		////{
		////	builder.ConfigureServices(services =>
		////	{
		////		services.AddControllers();


		////		services.AddSwaggerGen(c =>
		////		{
		////			c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookSolution", Version = "v1" });
		////		});



		////		services.AddAuthentication(opt =>
		////		{
		////			opt.DefaultAuthenticateScheme = "Key";
		////		})
		////		.AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("Key", option => { });

		////		services.AddExceptionMiddleware("test");

		////		services.AddAuthorization();

		////		services.AddAutoMapper(typeof(BookProfile).Assembly); //assembly of the application layer#
		////		services.AddScoped<BookService>();
		////		services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookDb"));
		////		services.AddSingleton<IGlobalExceptionHandler, GlobalExceptionHandler>();

		////	});
		////}
	}
}
