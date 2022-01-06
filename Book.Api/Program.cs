using Book.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookSolution
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var host = CreateHostBuilder(args).Build();			
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			var builder = Host.CreateDefaultBuilder(args)								
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

			return builder;
		}
	}
}
