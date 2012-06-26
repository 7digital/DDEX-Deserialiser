using NUnit.Framework;

namespace Deserialiser.Unit.Tests
{
	[TestFixture]
	public class ReadingMessageHeader : BigDdexXml
	{

		[Test]
		public void MessageThreadIdIsReadCorrectly()
		{
			ddex.root.MessageHeader.MessageThreadId.should_be_equal_to("MyMessageThreadId");
		}
	}
}
