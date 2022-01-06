using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Xunit;

namespace Book.Api.Test
{
	public class StreamTest
	{
		[Fact]
		public void Write()
		{
			using var outputStream = File.Create("D://test.dat");

			using TextWriter writer = new StreamWriter(outputStream);


			writer.WriteLine("heello");
		}

		[Fact]
		public void Read()
		{
			using var inputStream = File.Open("D://test.dat", FileMode.Open);

			using TextReader reader = new StreamReader(inputStream);


			Assert.Equal("heello", reader.ReadLine());
		}

		[Fact]
		public void Compress()
		{
			using var outputStream = File.Create("D://compress.bin");

			using var compressStream = new DeflateStream(outputStream, CompressionMode.Compress);

			using TextWriter textWriter = new StreamWriter(compressStream);


			textWriter.Write("Jolibeee");
		}

		[Fact]
		public void Decompress()
		{
			using var inputStream = File.Open("D://compress.bin", FileMode.Open);

			using var decompressStream = new DeflateStream(inputStream, CompressionMode.Decompress);

			using TextReader textReader = new StreamReader(decompressStream);


			Assert.Equal("Jolibeee", textReader.ReadLine());
		}

		[Fact]
		public void ReadMemory()
		{
			string text = "hello";
			using var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(text));

			using TextReader textReader = new StreamReader(inputStream);

			Assert.Equal(text, textReader.ReadToEnd());
		 
		}

		[Fact]
		public void WriteMemory()
		{
 
			using var outputStream = new MemoryStream();

			using TextWriter textWriter = new StreamWriter(outputStream);

			textWriter.Write("hello");
			textWriter.Flush();



			var actual = Encoding.UTF8.GetString(outputStream.ToArray());

			Assert.Equal("hello", actual);
			;
		}

		//[Fact]
		//public void Value()
		//{

		//	int x = 11;
		//	int y = 22;
		//	string n = "strin";

		//	var c = (x, y, n);
		//}

	}
}
