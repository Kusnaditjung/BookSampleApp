
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace Book.Api.Test
{
	public class SerialisationTest
	{


		[Fact]
		public void SerialisingTwo()
		{
			var order = new Order2 { Id = 1, Name = "kusnadi", Ignore = "ignore" };
			string a = System.Text.Json.JsonSerializer.Serialize(order);

			var _ = System.Text.Json.JsonSerializer.Deserialize<Order>(a);
		}

		[Fact]
		public void HttpClient()
		{
			var clientHandler = new HttpClientHandler();

			var client = new HttpClient(clientHandler)
			{
				BaseAddress = new Uri("https://www.kompas.com")
			};
			_ = client.GetAsync("/").Result;
		}
	}

	public class Order
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public string Ignore { get; set; }

		//public Order(int id, string name,  string ignore = null)
		//{
		//	this.Id = id;
		//	this.Name = name;
		//	this.Ignore = ignore;
		//}

	}

	public class Order2
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
		public string Ignore { get; set; }

		//public Order(int id, string name,  string ignore = null)
		//{
		//	this.Id = id;
		//	this.Name = name;
		//	this.Ignore = ignore;
		//}

	}

}
