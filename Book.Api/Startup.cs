using Book.Application.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book.Persistence;
using Microsoft.EntityFrameworkCore;
using Book.Application.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Book.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Book.Api.Filters;
using Book.Api.Authentication;
using Microsoft.AspNetCore.Authentication;
using System.Text.Json.Serialization;
using Book.Application.Query;
using System.Data.Common;
using System.Data.SqlClient;
using MediatR.Registration;
using MediatR.Pipeline;
using MediatR;

namespace BookSolution
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
				
	 
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookSolution", Version = "v1" });
			});

			

			//services.AddAuthentication(opt =>
			//{
			//	opt.DefaultAuthenticateScheme = "Key";
			//})
			//.AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("Key", option => { });

			//services.AddExceptionMiddleware("test");
			
			services.AddAuthorization();

			services.AddAutoMapper(typeof(BookProfile).Assembly); //assembly of the application layer#
			services.AddScoped<BookService>();
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookDatabase")));
			services.AddScoped<DbConnection>(builder => new SqlConnection(Configuration.GetConnectionString("BookDatabase")));
			//services.AddSingleton<IGlobalExceptionHandler, GlobalExceptionHandler>();
			services.AddConnections();
			services.AddMediatR(typeof(Book.Application.Commands.DeleteBook).Assembly);
			services.AddScoped<IBookQueryable, BookQueryable>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
		{			
			DbContextGenerator.Initialize(context);
 
			
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookSolution v1"));
			}

		//	app.UseExceptionMiddleware();
		
			//app.UseExceptionHandler(new ExceptionHandlerOptions
			//{		
			//	ExceptionHandler = globalExceptionHandler.Handle
			//});

			app.UseHttpsRedirection();			

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			
		//	app.UseHeader();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		
	}
}
