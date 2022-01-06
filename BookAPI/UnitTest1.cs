using System;
using System.IO;
using System.IO.Compression;
using Xunit;

namespace BookAPI
{
	public class UnitTest1
	{
		[Fact]
		public void Compress()
		{
			using var outputStream = File.Create("D://compress.bin");

			using var compressStream = new DeflateStream(outputStream, CompressionMode.Compress);

			using TextWriter textWriter = new StreamWriter(compressStream);


			textWriter.Write("Jolibeee");
		}

	}
}
