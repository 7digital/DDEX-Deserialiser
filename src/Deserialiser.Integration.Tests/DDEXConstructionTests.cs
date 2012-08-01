using System.IO;
using DDEX_Deserialiser;
using NUnit.Framework;

namespace Deserialiser.Unit.Tests
{
	[TestFixture]
	public class DDEXConstructionTests
	{
		[Test]
		public void Should_create_a_DDEX_from_file_path()
		{
			var ddex = new DDEX("artifacts/ddex-sample.xml");
			Assert.That(ddex, Is.Not.Null);
		}

		[Test]
		public void Should_create_a_DDEX_from_stream()
		{
			using (var fileStream = new FileStream("artifacts/ddex-sample.xml", FileMode.Open))
			{
				var ddex = new DDEX(fileStream);
				Assert.That(ddex, Is.Not.Null);
			}
		}
	}
}