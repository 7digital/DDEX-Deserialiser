using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
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

		[Test]
		public void Should_create_a_DDEX_from_XDocument()
		{
			XDocument document = XDocument.Load("artifacts/ddex-sample.xml");
			var ddex = new DDEX(document);
			Assert.That(ddex, Is.Not.Null);
		}

		[Test]
		public void Should_create_and_validate_DDEX_using_stream()
		{
			using (var fileStream = new FileStream("artifacts/ddex-sample.xml", FileMode.Open))
			{
				var ddex = new DDEX(fileStream, true);
				Assert.That(ddex, Is.Not.Null);
			}
		}

		[Test]
		public void Should_create_and_validate_DDEX_using_file_path()
		{
			var ddex = new DDEX("artifacts/ddex-sample.xml", true);
			Assert.That(ddex, Is.Not.Null);
		}

		[Test]
		public void Should_create_and_validate_DDEX_using_XDocument()
		{
			XDocument document = XDocument.Load("artifacts/ddex-sample.xml");
			var ddex = new DDEX(document, true);
			Assert.That(ddex, Is.Not.Null);
		}

		[Test]
		public void Should_throw_exception_if_DDEX_validation_fails_using_XDocument()
		{
			XDocument document = XDocument.Load("artifacts/Incorrect_DDEX.xml", LoadOptions.SetLineInfo);
			var ex = Assert.Throws<XmlSchemaValidationException>(() => new DDEX(document, true));
			Assert.That(ex.Message, Is.StringContaining("The element 'Release' has invalid child element 'InvalidNodeElement'. List of possible elements expected: 'ReleaseId'"));
			Assert.That(ex.LineNumber * ex.LinePosition, Is.Not.EqualTo(0));
		}

		[Test]
		public void Should_throw_exception_if_DDEX_validation_fails_using_file_path()
		{
			var ex = Assert.Throws<XmlSchemaValidationException>(() => new DDEX("artifacts/Incorrect_DDEX.xml", true));
			Assert.That(ex.Message, Is.StringContaining("The element 'Release' has invalid child element 'InvalidNodeElement'. List of possible elements expected: 'ReleaseId'"));
			Assert.That(ex.LineNumber * ex.LinePosition, Is.Not.EqualTo(0));
		}

		[Test]
		public void Should_throw_exception_if_DDEX_validation_fails_using_stream()
		{
			using (var fileStream = new FileStream("artifacts/Incorrect_DDEX.xml", FileMode.Open))
			{
				var ex = Assert.Throws<XmlSchemaValidationException>(() => new DDEX(fileStream, true));
				Assert.That(ex.Message, Is.StringContaining("The element 'Release' has invalid child element 'InvalidNodeElement'. List of possible elements expected: 'ReleaseId'"));
				Assert.That(ex.LineNumber * ex.LinePosition, Is.Not.EqualTo(0));
			}
		}
	}
}