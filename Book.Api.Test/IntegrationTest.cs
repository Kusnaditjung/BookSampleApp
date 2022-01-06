using Book.Application.Mappers;
using Book.Application.Services;
using Book.Persistence;
using BookSolution;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Book.Application.Dto;

namespace Book.Api.Test
{
	public class IntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> factory;
		public IntegrationTest(WebApplicationFactory<Startup> factory)
		{
			this.factory = factory;
			ConfigureService(factory);
		}

		[Fact]
		public async Task GetAllBooks_Normal_ReturnExpected()
		{
			var client = factory.CreateClient();
			var request = new System.Net.Http.HttpRequestMessage()
			{
				Method = System.Net.Http.HttpMethod.Get,
				RequestUri = new Uri("http://localhost/Book")
			};

			var res = await client.SendAsync(request);
			var tt = await res.Content.ReadAsStringAsync();
			var options = new System.Text.Json.JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var text = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<BookDto>>(tt, options);

		}

		private void ConfigureService(WebApplicationFactory<Startup> factory)
		{
			factory.WithWebHostBuilder(builder => {
				builder.ConfigureServices(services => {
					services.AddControllers();


					services.AddSwaggerGen(c =>
					{
						c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookSolution", Version = "v1" });
					});



					//services.AddAuthentication(opt =>
					//{
					//	opt.DefaultAuthenticateScheme = "Key";
					//})
					//.AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("Key", option => { });

				//	services.AddExceptionMiddleware("test");

					services.AddAuthorization();

					services.AddAutoMapper(typeof(BookProfile).Assembly); //assembly of the application layer#
					services.AddScoped<BookService>();
					services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("BookDb"));
	 

				});
			});

		}
	}
}
